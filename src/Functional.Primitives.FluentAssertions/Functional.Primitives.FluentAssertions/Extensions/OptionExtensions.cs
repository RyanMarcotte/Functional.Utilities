using System;

namespace Functional.Primitives.FluentAssertions.Extensions
{
	internal static class OptionExtensions
	{
		public static bool HasValue<T>(this Option<T> source) => source.Match(_ => true, () => false);
		public static T GetValue<T>(this Option<T> source) => source.Match(value => value, () => throw new InvalidOperationException("Attempted to access value, but none exists!"));
	}
}