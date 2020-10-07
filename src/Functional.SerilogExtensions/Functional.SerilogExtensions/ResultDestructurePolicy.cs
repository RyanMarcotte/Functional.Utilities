using System;
using System.Collections.Concurrent;
using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Functional.SerilogExtensions
{
	public class ResultDestructurePolicy : IDestructuringPolicy
	{
		private static readonly ConcurrentDictionary<(Type, Type), MethodInfo> _destructureResultMethodLookup = new ConcurrentDictionary<(Type, Type), MethodInfo>();
		private static readonly MethodInfo _destructureResultMethodInfo = typeof(ResultDestructurePolicy).GetMethod(nameof(TryDestructure_Impl), BindingFlags.Static | BindingFlags.NonPublic);

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
				.Invoke(null, new[] { value, propertyValueFactory });

			return true;
		}

		private static LogEventPropertyValue TryDestructure_Impl<TSuccess, TFailure>(Result<TSuccess, TFailure> result, ILogEventPropertyValueFactory propertyValueFactory)
		{
			return result.Match(
				success => propertyValueFactory.CreatePropertyValue(success, true),
				failure => propertyValueFactory.CreatePropertyValue(failure, true));
		}
	}
}