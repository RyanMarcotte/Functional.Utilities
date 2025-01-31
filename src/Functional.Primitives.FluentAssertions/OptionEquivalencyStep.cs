using FluentAssertions;
using FluentAssertions.Equivalency;
using System;
using FluentAssertions.Execution;

namespace Functional.Primitives.FluentAssertions
{
    /// <summary>
    /// Defines an equivalency step for comparing <see cref="Option{T}"/> when they are part of an object graph.
    /// </summary>
    /// <typeparam name="T">The contained type.</typeparam>
    public class OptionEquivalencyStep<T> : IEquivalencyStep
        where T : class
    {
        /// <inheritdoc />
        public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
        {
            if (comparands.Subject is not Option<T> subjectOption)
                return EquivalencyResult.ContinueWithNext;
            if (comparands.Expectation is not Option<T> expectationOption)
                return EquivalencyResult.ContinueWithNext;

            var subjectOptionHasValue = subjectOption.HasValue();
            var expectationOptionHasValue = expectationOption.HasValue();

            Execute.Assertion
                .ForCondition(subjectOptionHasValue == expectationOptionHasValue)
                .FailWith("Expected {context:subject} to be {0}, but found {1}.", expectationOption.ToString(), subjectOption.ToString());

            if (!subjectOptionHasValue || !expectationOptionHasValue)
                return EquivalencyResult.AssertionCompleted;

            var subject = subjectOption.ThrowOnNone(() => new InvalidOperationException("Expected value in subject!"));
            var expectation = expectationOption.ThrowOnNone(() => new InvalidOperationException("Expected value in expectation!"));

            subject.Should().BeEquivalentTo(expectation, context.Reason.FormattedMessage, context.Reason.Arguments);

            return EquivalencyResult.AssertionCompleted;
        }
    }
}
