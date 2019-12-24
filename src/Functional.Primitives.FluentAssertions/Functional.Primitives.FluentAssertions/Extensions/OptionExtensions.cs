using System;

namespace Functional.Primitives.FluentAssertions.Extensions
{
	internal static class OptionExtensions
	{
		public static T GetValue<T>(this Option<T> source) => source.Match(value => value, () => throw new InvalidOperationException("Attempted to access value, but none exists!"));

		public static T ValueUnsafe<T>(this Option<T> source)
			=> source.Match(x => x, () => throw new InvalidOperationException("Must have value!"));
	}
}