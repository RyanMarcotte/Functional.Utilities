using FluentAssertions;
using System;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public class UnionValueTypeAssertionsTests
	{
		public class ClassOne { }
		public static ClassOne ModelOne = new ClassOne();
		public class ClassTwo { }
		public static ClassTwo ModelTwo = new ClassTwo();

		public class TwoDefinition : UnionDefinition<TwoDefinition, ClassOne, ClassTwo> { }

		public class AdHocWithTwoTypes
		{
			[Fact]
			public void When_ExpectedTypeIsValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassTwo>()
			).Should().NotThrow();

			[Fact]
			public void When_ExpectedTypeIsNotValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassOne>()
			).Should().Throw<Exception>();

			[Fact]
			public void When_AdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassTwo>().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo>().Create(new ClassTwo()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();
		}

		public class DefinitionWithTwoTypes
		{
			[Fact]
			public void When_ExpectedTypeIsValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassTwo>()
			).Should().NotThrow();

			[Fact]
			public void When_ExpectedTypeIsNotValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassOne>()
			).Should().Throw<Exception>();

			[Fact]
			public void When_AdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfUnionType<ClassTwo>().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(new ClassTwo()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotValueType_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();
		}
	}
}
