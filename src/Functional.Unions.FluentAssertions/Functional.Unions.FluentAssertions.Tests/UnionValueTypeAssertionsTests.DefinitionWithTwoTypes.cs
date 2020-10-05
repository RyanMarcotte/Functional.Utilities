using FluentAssertions;
using System;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class DefinitionWithTwoTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().Be(Union.FromDefinition<TwoDefinition>().Create(new ClassTwo()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<TwoDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();
		}
	}
}
