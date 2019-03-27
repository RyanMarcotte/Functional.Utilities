using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using Functional.Primitives.FluentAssertions.Extensions;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Defines assertions for <see cref="Option{TValue}"/> type.
	/// </summary>
	/// <typeparam name="T">The contained type.</typeparam>
	public class OptionTypeAssertions<T>
	{
		private readonly Option<T> _subject;

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionTypeAssertions{T}"/> class.
		/// </summary>
		/// <param name="subject">The <see cref="Option{T}"/> instance to verify.</param>
		public OptionTypeAssertions(Option<T> subject)
		{
			_subject = subject;
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds a value.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void HaveValue(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.HasValue())
				.BecauseOf(because, becauseArgs)
				.FailWith($"Expected to have value, but received no value instead {{reason}}");
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds a value.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void HaveValue(Action<T> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			HaveValue(because, becauseArgs);
			additionalAssertionAction(_subject.GetValue());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds an expected value.
		/// </summary>
		/// <param name="expectedValue">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void HaveExpectedValue(T expectedValue, string because = "", params object[] becauseArgs)
			=> HaveExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds an expected value.
		/// </summary>
		/// <param name="expectedValue">The expected value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void HaveExpectedValue(T expectedValue, Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config, string because = "", params object[] becauseArgs)
		{
			HaveValue(because, becauseArgs);

			var value = _subject.GetValue();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected to have value '{expectedValue}', but received an incorrect value '{value}' instead.",
				becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> does not hold a value.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void NotHaveValue(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(!_subject.HasValue())
				.BecauseOf(because, becauseArgs)
				.FailWith($"Expected to not have value, but received a value instead {{reason}}");
		}
	}
}
