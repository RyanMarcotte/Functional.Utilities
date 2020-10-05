using System;
using System.ComponentModel;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Functional.Primitives.FluentAssertions.Extensions;

namespace Functional.Primitives.FluentAssertions
{
	public partial class OptionTypeAssertions<T>
	{
		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds a value.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		[Obsolete("Use HaveValue().AndValue.Should()... instead")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void HaveValue(Action<T> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			HaveValue(because, becauseArgs);
			additionalAssertionAction(_subject.ValueUnsafe());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds an expected value.
		/// </summary>
		/// <param name="expectedValue">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		[Obsolete("Use HaveValue().AndValue.Should()... instead")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void HaveExpectedValue(T expectedValue, string because = "", params object[] becauseArgs)
			=> HaveExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds an expected value.
		/// </summary>
		/// <param name="expectedValue">The expected value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		[Obsolete("Use HaveValue().AndValue.Should()... instead")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void HaveExpectedValue(T expectedValue, Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config, string because = "", params object[] becauseArgs)
		{
			HaveValue(because, becauseArgs);

			var value = _subject.ValueUnsafe();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected to have value '{expectedValue}', but received an incorrect value '{value}' instead.",
				becauseArgs);
		}
	}
}