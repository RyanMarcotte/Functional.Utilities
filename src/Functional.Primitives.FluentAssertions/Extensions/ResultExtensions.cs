using System;

namespace Functional.Primitives.FluentAssertions.Extensions
{
	internal static class ResultExtensions
	{
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.ThrowOnFailure(_ => throw new InvalidOperationException("Must be successful!"));

		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(_ => throw new InvalidOperationException("Must be faulted!"), x => x);
	}
}