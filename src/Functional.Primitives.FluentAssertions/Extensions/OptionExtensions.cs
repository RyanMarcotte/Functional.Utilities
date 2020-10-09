using System;

namespace Functional.Primitives.FluentAssertions.Extensions
{
	internal static class OptionExtensions
	{
		public static T ValueUnsafe<T>(this Option<T> source)
			=> source.ThrowOnNone(() => throw new InvalidOperationException("Must have value!"));
	}
}