using System;
using System.Collections.Concurrent;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Functional.SerilogExtensions
{
	public class OptionDestructurePolicy : IDestructuringPolicy
	{
		private static readonly ConcurrentDictionary<Type, MethodInfo> _destructureOptionMethodLookup = new ConcurrentDictionary<Type, MethodInfo>();
		private static readonly MethodInfo _destructureOptionMethodInfo = typeof(OptionDestructurePolicy).GetMethod(nameof(TryDestructure_Impl), BindingFlags.Static | BindingFlags.NonPublic);

		private readonly Func<object> _noValueFactory;

		public OptionDestructurePolicy()
			: this(() => null)
		{

		}

		public OptionDestructurePolicy(Func<object> noValueFactory)
		{
			_noValueFactory = noValueFactory ?? throw new ArgumentNullException(nameof(noValueFactory));
		}

		public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
		{
			result = null;

			var type = value.GetType();
			if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Option<>))
				return false;

			var optionType = type.GenericTypeArguments[0];
			
			result = (LogEventPropertyValue)_destructureOptionMethodLookup
				.GetOrAdd(optionType, x => _destructureOptionMethodInfo.MakeGenericMethod(optionType))
				.Invoke(null, new[] { value, propertyValueFactory, _noValueFactory });

			return true;
		}

		private static LogEventPropertyValue TryDestructure_Impl<T>(Option<T> option, ILogEventPropertyValueFactory propertyValueFactory, Func<object> noValueFactory)
		{
			return option.Match(
				value => propertyValueFactory.CreatePropertyValue(value, true),
				() => propertyValueFactory.CreatePropertyValue(noValueFactory.Invoke()));
		}
	}
}
