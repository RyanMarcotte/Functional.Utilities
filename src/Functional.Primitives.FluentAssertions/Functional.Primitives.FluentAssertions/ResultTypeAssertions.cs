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
	/// Defines assertions for <see cref="Result{TSuccess,TFailure}"/> type.
	/// </summary>
	/// <typeparam name="TSuccess">The success value type.</typeparam>
	/// <typeparam name="TFailure">The failure value type.</typeparam>
	public class ResultTypeAssertions<TSuccess, TFailure>
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
		public void BeSuccessful(string because = "", params object[] becauseArgs)
		{
			BeSuccessful(f => string.Empty, because, becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.
		/// </summary>
		/// <param name="faultedResultDescriptionFactory">The function used to construct a message describing the faulted result.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessful(Func<TFailure, string> faultedResultDescriptionFactory, string because = "", params object[] becauseArgs)
		{
			if (faultedResultDescriptionFactory == null) throw new ArgumentNullException(nameof(faultedResultDescriptionFactory));

			_subject.Apply(_ => { /* DO NOTHING */}, failure =>
			{
				var description = faultedResultDescriptionFactory.Invoke(failure);
				var descriptionToDisplay = !string.IsNullOrEmpty(description)
					? $"{Environment.NewLine}{Environment.NewLine}Faulted result description:{Environment.NewLine}{description}"
					: string.Empty;

				Execute.Assertion
					.BecauseOf(because, becauseArgs)
					.FailWith($"Expected result to be successful, but received faulted result instead {{reason}}" + descriptionToDisplay);
			});
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessful(Action<TSuccess> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			BeSuccessful(s => string.Empty, additionalAssertionAction, because, becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="faultedResultDescriptionFactory">The function used to construct a message describing the faulted result.</param>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessful(Func<TFailure, string> faultedResultDescriptionFactory, Action<TSuccess> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (faultedResultDescriptionFactory == null) throw new ArgumentNullException(nameof(faultedResultDescriptionFactory));
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			BeSuccessful(faultedResultDescriptionFactory, because, becauseArgs);
			additionalAssertionAction(_subject.GetSuccessValue());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific successful result.  Useful error messages require <typeparamref name="TSuccess"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected successful value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessfulWithExpectedValue(TSuccess expectedValue, string because = "", params object[] becauseArgs)
			=> BeSuccessfulWithExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific successful result.  Useful error messages require <typeparamref name="TSuccess"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected successful value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessfulWithExpectedValue(TSuccess expectedValue, Func<EquivalencyAssertionOptions<TSuccess>, EquivalencyAssertionOptions<TSuccess>> config, string because = "", params object[] becauseArgs)
		{
			BeSuccessful(because, becauseArgs);

			var value = _subject.GetSuccessValue();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected result to be successful with value '{expectedValue}', but received successful result with value '{value}' instead.",
				becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(string because = "", params object[] becauseArgs)
		{
			BeFaulted(s => string.Empty, because, becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <param name="successfulResultDescriptionFactory">The function used to construct a message describing the successful result.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(Func<TSuccess, string> successfulResultDescriptionFactory, string because = "", params object[] becauseArgs)
		{
			if (successfulResultDescriptionFactory == null) throw new ArgumentNullException(nameof(successfulResultDescriptionFactory));

			_subject.Apply(success =>
			{
				var description = successfulResultDescriptionFactory.Invoke(success);
				var descriptionToDisplay = !string.IsNullOrEmpty(description)
					? $"{Environment.NewLine}{Environment.NewLine}Faulted result description:{Environment.NewLine}{description}"
					: string.Empty;

				Execute.Assertion
					.ForCondition(!_subject.IsSuccessful())
					.BecauseOf(because, becauseArgs)
					.FailWith($"Expected result to be faulted, but received successful result instead {{reason}}" + descriptionToDisplay);

			}, _ => { /* DO NOTHING */});
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(Action<TFailure> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			BeFaulted(s => string.Empty, additionalAssertionAction, because, becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="successfulResultDescriptionFactory">The function used to construct a message describing the successful result.</param>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(Func<TSuccess, string> successfulResultDescriptionFactory, Action<TFailure> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (successfulResultDescriptionFactory == null) throw new ArgumentNullException(nameof(successfulResultDescriptionFactory));
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			BeFaulted(successfulResultDescriptionFactory, because, becauseArgs);
			additionalAssertionAction(_subject.GetFailureValue());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific faulted result.  Useful error messages require <typeparamref name="TFailure"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected faulted value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaultedWithExpectedValue(TFailure expectedValue, string because = "", params object[] becauseArgs)
			=> BeFaultedWithExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific faulted result.  Useful error messages require <typeparamref name="TFailure"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected faulted value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaultedWithExpectedValue(TFailure expectedValue, Func<EquivalencyAssertionOptions<TFailure>, EquivalencyAssertionOptions<TFailure>> config, string because = "", params object[] becauseArgs)
		{
			BeFaulted(because, becauseArgs);

			var value = _subject.GetFailureValue();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected result to be faulted with value '{expectedValue}', but received faulted result with value '{value}' instead.",
				becauseArgs);
		}
	}
}
