using System;

namespace Functional.Unions.FluentAssertions.Extensions
{
	internal static class OptionExtensions
	{
		public static T ValueUnsafe<T>(this Option<T> source)
			=> source.Match(x => x, () => throw new InvalidOperationException("Must have value!"));
	}
}
