﻿using FluentAssertions;
using System;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class DefinitionWithThreeTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value().Should().Be(Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value().Should().Be(Union.FromDefinition<ThreeDefinition>().Create(new ClassThree()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();
		}
	}
}
