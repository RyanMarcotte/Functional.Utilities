using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Functional.Unions.FluentAssertions.Extensions;
using System;
using static Functional.Unions.FluentAssertions.Extensions.UnionExtensions;

namespace Functional.Unions.FluentAssertions
{
	public class UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo>
		where TUnionType : struct
		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
	{
		private readonly IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> _subject;

		public UnionValueTypeAssertions(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> unionValue)
		{
			_subject = unionValue;
		}

		/// <summary>
		///  Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public AndConstraint<ObjectAssertions> Be(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> expected, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.Equals(expected))
				.BecauseOf(because, becauseArgs)
				.FailWith(() => GetFailReasonForBe<TUnionDefinition>(_subject, expected));

			return new AndConstraint<ObjectAssertions>(new ObjectAssertions(_subject));
		}

		/// <summary>
		///  Verifies that the subject's value is of a particular type in the Union
		/// </summary>
		/// <typeparam name="TExpected">The type in the Union that the value is expected to be of.</typeparam>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <param name="ignore">Ignore this parameter as it should always be the default value.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TOne> BeOfUnionType<TExpected>(string because = "", object[] becauseArgs = default, TOne ignore = default)
			where TExpected : TOne
			=> BeOfUnionType(() => _subject.One().ThrowOnNone(() => throw new InvalidOperationException("Must have value!")), because, becauseArgs);

		/// <summary>
		///  Verifies that the subject's value is of a particular type in the Union
		/// </summary>
		/// <typeparam name="TExpected">The type in the Union that the value is expected to be of.</typeparam>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <param name="ignore">Ignore this parameter as it should always be the default value.</param>
		/// <returns></returns>
		public AndUnionValueConstraint<TTwo> BeOfUnionType<TExpected>(string because = "", object[] becauseArgs = default, TTwo ignore = default)
			where TExpected : TTwo
			=> BeOfUnionType(() => _subject.Two().ThrowOnNone(() => throw new InvalidOperationException("Must have value!")), because, becauseArgs);

		private AndUnionValueConstraint<TExpected> BeOfUnionType<TExpected>(Func<TExpected> getValue, string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.BecauseOf(because, becauseArgs)
				.ForCondition(_subject.GetValueType() == typeof(TExpected))
				.FailWith(() => GetFailReasonForBeOfType<TExpected>(_subject.GetValueType(), _subject));
			return new AndUnionValueConstraint<TExpected>(getValue());
		}
	}
}
