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

		private readonly Func<object, object> _successValueFactory;
		private readonly Func<object, object> _failureValueFactory;

		public ResultDestructurePolicy()
			: this(success => new { IsSuccessful = true, Data = success }, failure => new { IsSuccessful = false, Data = failure })
		{

		}

		public ResultDestructurePolicy(Func<object, object> successValueFactory, Func<object, object> failureValueFactory)
		{
			_successValueFactory = successValueFactory ?? throw new ArgumentNullException(nameof(successValueFactory));
			_failureValueFactory = failureValueFactory ?? throw new ArgumentNullException(nameof(failureValueFactory));
		}

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
				.Invoke(null, new[] { value, propertyValueFactory, _successValueFactory, _failureValueFactory });

			return true;
		}

		private static LogEventPropertyValue TryDestructure_Impl<TSuccess, TFailure>(
			Result<TSuccess, TFailure> result,
			ILogEventPropertyValueFactory propertyValueFactory,
			Func<object, object> successValueFactory,
			Func<object, object> failureValueFactory)
		{
			return result.Match(
				success => propertyValueFactory.CreatePropertyValue(successValueFactory.Invoke(success), true),
				failure => propertyValueFactory.CreatePropertyValue(failureValueFactory.Invoke(failure), true));
	}
	}
}