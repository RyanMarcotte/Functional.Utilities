using System;
using System.Diagnostics;
using FluentAssertions.Execution;
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
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public AndValueConstraint<TSuccess> BeSuccessful(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.ForCondition(_subject.IsSuccess())
				.FailWith(FailReasonForBeSuccessful);

			return new AndValueConstraint<TSuccess>(_subject.SuccessUnsafe());
		}

		private FailReason FailReasonForBeSuccessful()
		{
			return new FailReason("Expected result to be successful, but received faulted result instead{reason}:"
			                      + Environment.NewLine
			                      + _subject.FailureUnsafe());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public AndValueConstraint<TFailure> BeFaulted(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.ForCondition(!_subject.IsSuccess())
				.FailWith(FailReasonForBeFaulted);

			return new AndValueConstraint<TFailure>(_subject.FailureUnsafe());
		}

		private FailReason FailReasonForBeFaulted()
		{
			return new FailReason("Expected result to be faulted, but received successful result instead{reason}:"
			                      + Environment.NewLine
			                      + _subject.SuccessUnsafe());
		}
	}

	internal static class ResultExtensions
	{
		public static TSuccess SuccessUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(x => x, _ => throw new InvalidOperationException("Must be successful!"));

		public static TFailure FailureUnsafe<TSuccess, TFailure>(this Result<TSuccess, TFailure> source)
			=> source.Match(_ => throw new InvalidOperationException("Must be faulted!"), x => x);
	}
}
