using System;
using System.Collections.Concurrent;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Functional.SerilogExtensions
{
	/// <summary>
	/// Determine how, when destructuring, a supplied <see cref="Option{TValue}"/> is represented as a complex log event property.
	/// </summary>
	public class OptionDestructurePolicy : IDestructuringPolicy
	{
		private static readonly ConcurrentDictionary<Type, MethodInfo> _destructureOptionMethodLookup = new ConcurrentDictionary<Type, MethodInfo>();
		private static readonly MethodInfo _destructureOptionMethodInfo = typeof(OptionDestructurePolicy).GetMethod(nameof(TryDestructure_Impl), BindingFlags.Static | BindingFlags.NonPublic);

		private readonly OptionDestructurePolicyConfiguration _configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionDestructurePolicy"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public OptionDestructurePolicy(OptionDestructurePolicyConfiguration configuration)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		/// <summary>
		/// If supported, destructure the provided value.
		/// </summary>
		/// <param name="value">The value to destructure.</param>
		/// <param name="propertyValueFactory">Recursively apply policies to destructure additional values.</param>
		/// <param name="result">The destructured value, or null.</param>
		/// <returns>True if the value could be destructured under this policy.</returns>
		public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
		{
			result = null;

			var type = value.GetType();
			if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Option<>))
				return false;

			var optionType = type.GenericTypeArguments[0];
			
			result = (LogEventPropertyValue)_destructureOptionMethodLookup
				.GetOrAdd(optionType, x => _destructureOptionMethodInfo.MakeGenericMethod(optionType))
				.Invoke(null, new[] { value, propertyValueFactory, _configuration });

			return true;
		}

		private static LogEventPropertyValue TryDestructure_Impl<T>(Option<T> option, ILogEventPropertyValueFactory propertyValueFactory, OptionDestructurePolicyConfiguration configuration)
		{
			return option.Match(
				value => propertyValueFactory.CreatePropertyValue(configuration.ValueFactory.Invoke(value), true),
				() => propertyValueFactory.CreatePropertyValue(configuration.NoValueFactory.Invoke(), true));
		}
	}
}
