using System;
using System.Diagnostics;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Functional.Primitives.FluentAssertions.Extensions;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Defines assertions for <see cref="Option{TValue}"/> type.
	/// </summary>
	/// <typeparam name="T">The contained type.</typeparam>
	[DebuggerNonUserCode]
	public partial class OptionTypeAssertions<T>
	{
		private const string IDENTIFIER = "option";

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
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		[CustomAssertion]
		public AndConstraint<ObjectAssertions> Be(Option<T> expected, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.Equals(expected))
				.BecauseOf(because, becauseArgs)
				.WithDefaultIdentifier(IDENTIFIER)
				.FailWith(MakeFailReason);

			return new AndConstraint<ObjectAssertions>(new ObjectAssertions(_subject));

			FailReason MakeFailReason()
			{
				var builder = new StringBuilder();
				builder.AppendLine($"Expected {{context:{IDENTIFIER}}} to be equal to the expected value{{reason}}, but the two Option<{typeof(T)}> are not equal.");
				builder.AppendLine("Subject: " + _subject);
				builder.AppendLine("Expected: " + expected);

				return new FailReason(builder.ToString());
			}
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> holds a value.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		[CustomAssertion]
		public AndOptionValueConstraint<T> HaveValue(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.HasValue())
				.BecauseOf(because, becauseArgs)
				.WithDefaultIdentifier(IDENTIFIER)
				.FailWith($"Expected {{context:{IDENTIFIER}}} to have value{{reason}}, but received no value instead.", _subject);

			return new AndOptionValueConstraint<T>(_subject.ValueUnsafe());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Option{T}"/> does not hold a value.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		[CustomAssertion]
		public void NotHaveValue(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(!_subject.HasValue())
				.BecauseOf(because, becauseArgs)
				.WithDefaultIdentifier(IDENTIFIER)
				.FailWith(FailReasonForNotHaveValue);

			FailReason FailReasonForNotHaveValue()
			{
				var builder = new StringBuilder();
				builder.AppendLine($"Expected {{context:{IDENTIFIER}}} to not have value{{reason}}, but received a value instead:");
				builder.AppendLine(_subject.ValueUnsafe().ToString());

				return new FailReason(builder.ToString());
			}
		}
	}
}
