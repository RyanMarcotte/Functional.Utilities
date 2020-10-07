using System;
using System.Collections.Concurrent;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Functional.SerilogExtensions
{
	/// <summary>
	/// Determine how, when destructuring, a supplied <see cref="Result{TSuccess,TFailure}"/> is represented as a complex log event property.
	/// </summary>
	public class ResultDestructurePolicy : IDestructuringPolicy
	{
		private static readonly ConcurrentDictionary<(Type, Type), MethodInfo> _destructureResultMethodLookup = new ConcurrentDictionary<(Type, Type), MethodInfo>();
		private static readonly MethodInfo _destructureResultMethodInfo = typeof(ResultDestructurePolicy).GetMethod(nameof(TryDestructure_Impl), BindingFlags.Static | BindingFlags.NonPublic);

		private readonly ResultDestructurePolicyConfiguration _configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultDestructurePolicy"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public ResultDestructurePolicy(ResultDestructurePolicyConfiguration configuration)
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
			if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Result<,>))
				return false;

			var successType = type.GenericTypeArguments[0];
			var failureType = type.GenericTypeArguments[1];

			result = (LogEventPropertyValue)_destructureResultMethodLookup
				.GetOrAdd((successType, failureType), tuple => _destructureResultMethodInfo.MakeGenericMethod(tuple.Item1, tuple.Item2))
				.Invoke(null, new[] { value, propertyValueFactory, _configuration });

			return true;
		}

		private static LogEventPropertyValue TryDestructure_Impl<TSuccess, TFailure>(Result<TSuccess, TFailure> result, ILogEventPropertyValueFactory propertyValueFactory, ResultDestructurePolicyConfiguration configuration)
		{
			return result.Match(
				success => propertyValueFactory.CreatePropertyValue(configuration.SuccessValueFactory.Invoke(success), true),
				failure => propertyValueFactory.CreatePropertyValue(configuration.FailureValueFactory.Invoke(failure), true));
	}
	}
}