using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FluentAssertions.Execution;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Defines assertions for <see cref="Option{TValue}"/> type.
	/// </summary>
	/// <typeparam name="T">The contained type.</typeparam>
	[DebuggerNonUserCode]
	public partial class OptionTypeAssertions<T>
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
		public AndValueConstraint<T> HaveValue(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.HasValue())
				.BecauseOf(because, becauseArgs)
				.FailWith("Expected to have value, but received no value instead {reason}");

			return new AndValueConstraint<T>(_subject.ValueUnsafe());
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
				.FailWith(FailReasonForNotHaveValue);
		}

		private FailReason FailReasonForNotHaveValue()
		{
			return new FailReason("Expected to not have value, but received a value instead {reason}"
			                      + Environment.NewLine
			                      + Environment.NewLine
			                      + "Value:"
			                      + _subject.ValueUnsafe());
		}
	}

	internal static class OptionExtensions
	{
		public static T ValueUnsafe<T>(this Option<T> source)
			=> source.Match(x => x, () => throw new InvalidOperationException("Must have value!"));
	}
}
