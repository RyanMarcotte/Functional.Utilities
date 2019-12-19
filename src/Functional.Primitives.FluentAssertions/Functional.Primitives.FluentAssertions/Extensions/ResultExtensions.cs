using System;

namespace Functional.Primitives.FluentAssertions.Extensions
{
	internal static class ResultExtensions
	{
		public static TSuccess GetSuccessValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> source) => source.Match(value => value, _ => throw new InvalidOperationException("Attempted to access value from success case, but none exists!"));
		public static TFailure GetFailureValue<TSuccess, TFailure>(this Result<TSuccess, TFailure> source) => source.Match(_ => throw new InvalidOperationException("Attempted to access value from failure case, but none exists!"), value => value);
	}
}