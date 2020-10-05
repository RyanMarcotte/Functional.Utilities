using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Functional.Unions.FluentAssertions.Extensions;
using System;
using static Functional.Unions.FluentAssertions.Extensions.UnionExtensions;

namespace Functional.Unions.FluentAssertions
{
	public class UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
		where TUnionType : struct
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
	{
		private readonly IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> _subject;

		public UnionValueTypeAssertions(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> unionValue)
		{
			_subject = unionValue;
		}

		/// <summary>
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndConstraint<ObjectAssertions> Be(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> expected, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.Equals(expected))
				.BecauseOf(because, becauseArgs)
				.FailWith(() => GetFailReasonForBe<TUnionDefinition>(_subject, expected));

			return new AndConstraint<ObjectAssertions>(new ObjectAssertions(_subject));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TOne"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TOne> BeOfTypeOne(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.One().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TOne>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TOne>(_subject.One().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TTwo"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TTwo> BeOfTypeTwo(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Two().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TTwo>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TTwo>(_subject.Two().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TThree"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TThree> BeOfTypeThree(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Three().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TThree>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TThree>(_subject.Three().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TFour"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TFour> BeOfTypeFour(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Four().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TFour>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TFour>(_subject.Four().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TFive"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TFive> BeOfTypeFive(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Five().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TFive>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TFive>(_subject.Five().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TSix"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TSix> BeOfTypeSix(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Six().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TSix>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TSix>(_subject.Six().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TSeven"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TSeven> BeOfTypeSeven(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Seven().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TSeven>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TSeven>(_subject.Seven().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}
	}
}
