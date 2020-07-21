using System;
using System.Diagnostics;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Functional.Primitives.FluentAssertions.Extensions;

// ReSharper disable ImpureMethodCallOnReadonlyValueField
namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Defines assertions for <see cref="Result{TSuccess,TFailure}"/> type.
	/// </summary>
	/// <typeparam name="TSuccess">The success value type.</typeparam>
	/// <typeparam name="TFailure">The failure value type.</typeparam>
	[DebuggerNonUserCode]
	public partial class ResultTypeAssertions<TSuccess, TFailure>
	{
		private readonly Result<TSuccess, TFailure> _subject;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> class.
		/// </summary>
		/// <param name="subject">The <see cref="Result{TSuccess, TFailure}"/> instance to verify.</param>
		public ResultTypeAssertions(Result<TSuccess, TFailure> subject)
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
		public AndConstraint<ObjectAssertions> Be(Result<TSuccess, TFailure> expected, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.Equals(expected))
				.BecauseOf(because, becauseArgs)
				.FailWith(MakeFailReason);

			return new AndConstraint<ObjectAssertions>(new ObjectAssertions(_subject));

			FailReason MakeFailReason()
			{
				var builder = new StringBuilder();
				builder.AppendLine($"Expected to be equal{{reason}}, but the two Result<{typeof(TSuccess)}, {typeof(TFailure)}> are not equal.");
				builder.AppendLine("Subject: " + _subject);
				builder.AppendLine("Expected: " + expected);

				return new FailReason(builder.ToString());
			}
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public AndResultSuccessConstraint<TSuccess> BeSuccessful(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.ForCondition(_subject.IsSuccess())
				.FailWith(FailReasonForBeSuccessful);

			return new AndResultSuccessConstraint<TSuccess>(_subject.SuccessUnsafe());

			FailReason FailReasonForBeSuccessful()
			{
				var builder = new StringBuilder();
				builder.AppendLine("Expected result to be successful{reason}, but received faulted result instead:");
				builder.AppendLine(_subject.FailureUnsafe().ToString());

				return new FailReason(builder.ToString());
			}
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public AndResultFailureConstraint<TFailure> BeFaulted(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.ForCondition(!_subject.IsSuccess())
				.FailWith(FailReasonForBeFaulted);

			return new AndResultFailureConstraint<TFailure>(_subject.FailureUnsafe());

			FailReason FailReasonForBeFaulted()
			{
				var builder = new StringBuilder();
				builder.AppendLine("Expected result to be faulted{reason}, but received successful result instead:");
				builder.AppendLine(_subject.SuccessUnsafe().ToString());

				return new FailReason(builder.ToString());
			}
		}
	}
}
