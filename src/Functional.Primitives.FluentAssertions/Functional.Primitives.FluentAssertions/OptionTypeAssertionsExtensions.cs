using FluentAssertions;
using FluentAssertions.Primitives;
using Functional.Primitives.FluentAssertions;
using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace (ease of discoverability)
namespace Functional
{
	/// <summary>
	/// A collection of extensions for <see cref="OptionTypeAssertions{T}"/>
	/// </summary>
	public static class OptionTypeAssertionsExtensions
	{
		/// <summary>
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <typeparam name="T">The contained type.</typeparam>
		/// <param name="source">The source <see cref="OptionTypeAssertions{T}"/> task.</param>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndConstraint<ObjectAssertions>> Be<T>(this Task<OptionTypeAssertions<T>> source, Option<T> expected, string because = "", params object[] becauseArgs)
			=> (await source).Be(expected, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds a value.
		/// </summary>
		/// <typeparam name="T">The contained type.</typeparam>
		/// <param name="source">The source <see cref="OptionTypeAssertions{T}"/> task.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public static async Task<AndOptionValueConstraint<T>> HaveValue<T>(this Task<OptionTypeAssertions<T>> source, string because = "", params object[] becauseArgs)
			=> (await source).HaveValue(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> does not hold a value.
		/// </summary>
		/// <typeparam name="T">The contained type.</typeparam>
		/// <param name="source">The source <see cref="OptionTypeAssertions{T}"/> task.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task NotHaveValue<T>(this Task<OptionTypeAssertions<T>> source, string because = "", params object[] becauseArgs)
			=> (await source).NotHaveValue(because, becauseArgs);

		/// <summary>
		/// Invokes the provided action on the value of the option.
		/// </summary>
		/// <typeparam name="T">The contained type.</typeparam>
		/// <param name="source">The <see cref="AndOptionValueConstraint{T}"/> with the possible value to perform additional assertion actions on.</param>
		/// <param name="action">The assertion action to perform on the option's value.</param>
		public static async Task AndValue<T>(this Task<AndOptionValueConstraint<T>> source, Action<T> action)
			=> action((await source).AndValue);
	}
}
