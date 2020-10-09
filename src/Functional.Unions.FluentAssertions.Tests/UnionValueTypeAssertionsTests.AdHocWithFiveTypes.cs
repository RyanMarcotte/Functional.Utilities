using FluentAssertions;
using System;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class AdHocWithFiveTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(new ClassFive()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();
		}
	}
}
