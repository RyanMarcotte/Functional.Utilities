using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Functional.Unions.FluentAssertions.Extensions;
using System;
using static Functional.Unions.FluentAssertions.Extensions.UnionExtensions;

namespace Functional.Unions.FluentAssertions
{
	/// <summary>
	/// Contains a number to methods to assert that an <see cref="IUnionValue{TUnionDefinition}"/> is in an expected state.
	/// </summary>
	/// <typeparam name="TUnionType"></typeparam>
	/// <typeparam name="TUnionDefinition"></typeparam>
	/// <typeparam name="TOne"></typeparam>
	/// <typeparam name="TTwo"></typeparam>
	/// <typeparam name="TThree"></typeparam>
	/// <typeparam name="TFour"></typeparam>
	/// <typeparam name="TFive"></typeparam>
	/// <typeparam name="TSix"></typeparam>
	/// <typeparam name="TSeven"></typeparam>
	/// <typeparam name="TEight"></typeparam>
	public class UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
		where TUnionType : struct
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
	{
		private readonly IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> _subject;

		/// <summary>
		/// Initializes a new instance of the <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven,TEight}"/> class.
		/// </summary>
		/// <param name="unionValue"></param>
		public UnionValueTypeAssertions(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> unionValue)
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
		public AndConstraint<ObjectAssertions> Be(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> expected, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.Equals(expected))
				.BecauseOf(because, becauseArgs)
				.FailWith(() => GetFailReasonForBe<TUnionDefinition>(_subject, expected));

			return new AndConstraint<ObjectAssertions>(new ObjectAssertions(_subject));
		}

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TOne"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TTwo"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TThree"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TFour"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TFive"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TSix"/>.
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
		/// Verifies that the subject's value is of type <typeparamref name="TSeven"/>.
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

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TEight"/>.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TEight> BeOfTypeEight(string because = "", object[] becauseArgs = default)
		{
			Execute.Assertion
			.BecauseOf(because, becauseArgs)
			.ForCondition(_subject.Eight().HasValue())
			.FailWith(() => GetFailReasonForBeOfType<TEight>(_subject.GetValueType(), _subject));

			return new AndUnionValueConstraint<TEight>(_subject.Eight().ThrowOnNone(() => new InvalidOperationException("Must have value!")));
		}
	}
}
