using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class TaskAdHocWithSevenTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven)).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value())
			).Should().NotThrowAsync();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven)).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(new ClassSeven()).Value())
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne)).Value().Should().BeOfTypeOne()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne)).Value().Should().BeOfTypeTwo()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo)).Value().Should().BeOfTypeTwo()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo)).Value().Should().BeOfTypeOne()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree)).Value().Should().BeOfTypeThree()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree)).Value().Should().BeOfTypeTwo()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour)).Value().Should().BeOfTypeFour()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour)).Value().Should().BeOfTypeThree()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive)).Value().Should().BeOfTypeFive()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive)).Value().Should().BeOfTypeFour()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix)).Value().Should().BeOfTypeSix()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix)).Value().Should().BeOfTypeFive()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsSeven_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven)).Value().Should().BeOfTypeSeven()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsNotSeven_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven)).Value().Should().BeOfTypeSix()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne)).Value().Should().BeOfTypeOne().AndValue(value => value.Should().Be(ModelOne))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo)).Value().Should().BeOfTypeTwo().AndValue(value => value.Should().Be(ModelTwo))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree)).Value().Should().BeOfTypeThree().AndValue(value => value.Should().Be(ModelThree))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour)).Value().Should().BeOfTypeFour().AndValue(value => value.Should().Be(ModelFour))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive)).Value().Should().BeOfTypeFive().AndValue(value => value.Should().Be(ModelFive))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix)).Value().Should().BeOfTypeSix().AndValue(value => value.Should().Be(ModelSix))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsSevenAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven)).Value().Should().BeOfTypeSeven().AndValue(value => value.Should().Be(ModelSeven))
			).Should().NotThrowAsync();
		}
	}
}
