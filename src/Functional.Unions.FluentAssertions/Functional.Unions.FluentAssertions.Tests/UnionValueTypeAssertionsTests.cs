using FluentAssertions;
using System;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public class UnionValueTypeAssertionsTests
	{
		public class TOne { }
		public static TOne One = new TOne();
		public class TTwo { }
		public static TTwo Two = new TTwo();

		public class TwoDefinition : UnionDefinition<TwoDefinition, TOne, TTwo> { }

		public class AdHocWithTwoTypes
		{
			[Fact]
			public void When_ExpectedTypeIsValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<TOne, TTwo>().Create(Two).Value().Should().BeOfUnionType<TTwo>()
			).Should().NotThrow();

			[Fact]
			public void When_ExpectedTypeIsNotValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<TOne, TTwo>().Create(Two).Value().Should().BeOfUnionType<TOne>()
			).Should().Throw<Exception>();

			[Fact]
			public void When_AdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<TOne, TTwo>().Create(Two).Value().Should().BeOfUnionType<TTwo>().AndValue.Should().Be(Two)
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<TOne, TTwo>().Create(Two).Value().Should().Be(Union.FromTypes<TOne, TTwo>().Create(Two).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<TOne, TTwo>().Create(Two).Value().Should().Be(Union.FromTypes<TOne, TTwo>().Create(new TTwo()).Value())
			).Should().Throw<Exception>();
		}

		public class DefinitionWithTwoTypes
		{
			[Fact]
			public void When_ExpectedTypeIsValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(Two).Value().Should().BeOfUnionType<TTwo>()
			).Should().NotThrow();

			[Fact]
			public void When_ExpectedTypeIsNotValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(Two).Value().Should().BeOfUnionType<TOne>()
			).Should().Throw<Exception>();

			[Fact]
			public void When_AdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(Two).Value().Should().BeOfUnionType<TTwo>().AndValue.Should().Be(Two)
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(Two).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(Two).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(Two).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(new TTwo()).Value())
			).Should().Throw<Exception>();
		}
	}
}
