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
		public class ClassThree { }
		public static ClassThree ModelThree = new ClassThree();
		public class ClassFour { }
		public static ClassFour ModelFour = new ClassFour();
		public class ClassFive { }
		public static ClassFive ModelFive = new ClassFive();
		public class ClassSix { }
		public static ClassSix ModelSix = new ClassSix();
		public class ClassSeven { }
		public static ClassSeven ModelSeven = new ClassSeven();
		public class ClassEight { }
		public static ClassEight ModelEight = new ClassEight();

		public class TwoDefinition : UnionDefinition<TwoDefinition, ClassOne, ClassTwo> { }
		public class ThreeDefinition : UnionDefinition<ThreeDefinition, ClassOne, ClassTwo, ClassThree> { }
		public class FourDefinition : UnionDefinition<FourDefinition, ClassOne, ClassTwo, ClassThree, ClassFour> { }
		public class FiveDefinition : UnionDefinition<FiveDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive> { }
		public class SixDefinition : UnionDefinition<SixDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix> { }
		public class SevenDefinition : UnionDefinition<SevenDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven> { }
		public class EightDefinition : UnionDefinition<EightDefinition, ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight> { }

		public class AdHocWithTwoTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo>().Create(new ClassTwo()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();
		}

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

		public class AdHocWithThreeTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(new ClassThree()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();
		}

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

		public class AdHocWithFourTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(new ClassFour()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();
		}

		public class DefinitionWithFourTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelFour).Value().Should().Be(Union.FromDefinition<FourDefinition>().Create(ModelFour).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelFour).Value().Should().Be(Union.FromDefinition<FourDefinition>().Create(new ClassFour()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FourDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();
		}

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

		public class DefinitionWithFiveTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value().Should().Be(Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value().Should().Be(Union.FromDefinition<FiveDefinition>().Create(new ClassFive()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<FiveDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();
		}

		public class AdHocWithSixTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(new ClassSix()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();
		}

		public class DefinitionWithSixTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelSix).Value().Should().Be(Union.FromDefinition<SixDefinition>().Create(ModelSix).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelSix).Value().Should().Be(Union.FromDefinition<SixDefinition>().Create(new ClassSix()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SixDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();
		}

		public class AdHocWithSevenTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(new ClassSeven()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsSeven_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value().Should().BeOfTypeSeven()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsNotSeven_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value().Should().BeOfTypeSix()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven>().Create(ModelSeven).Value().Should().BeOfTypeSeven().AndValue.Should().Be(ModelSeven)
			).Should().NotThrow();
		}

		public class DefinitionWithSevenTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value().Should().Be(Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value().Should().Be(Union.FromDefinition<SevenDefinition>().Create(new ClassSeven()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsSeven_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSeven()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsNotSeven_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSix()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<SevenDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSeven().AndValue.Should().Be(ModelSeven)
			).Should().NotThrow();
		}

		public class AdHocWithEightTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value().Should().Be(Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(new ClassEight()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsSeven_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSeven).Value().Should().BeOfTypeSeven()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsNotSeven_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSeven).Value().Should().BeOfTypeSix()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsEightAndExpectedTypeIsEight_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value().Should().BeOfTypeEight()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsEightAndExpectedTypeIsNotEight_Then_ShouldThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value().Should().BeOfTypeSeven()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelSeven).Value().Should().BeOfTypeSeven().AndValue.Should().Be(ModelSeven)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsEightAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromTypes<ClassOne, ClassTwo, ClassThree, ClassFour, ClassFive, ClassSix, ClassSeven, ClassEight>().Create(ModelEight).Value().Should().BeOfTypeEight().AndValue.Should().Be(ModelEight)
			).Should().NotThrow();
		}

		public class DefinitionWithEightTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelEight).Value().Should().Be(Union.FromDefinition<EightDefinition>().Create(ModelEight).Value())
			).Should().NotThrow();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelEight).Value().Should().Be(Union.FromDefinition<EightDefinition>().Create(new ClassEight()).Value())
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelOne).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelTwo).Value().Should().BeOfTypeOne()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelThree).Value().Should().BeOfTypeTwo()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsFour_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndExpectedTypeIsNotFour_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFour).Value().Should().BeOfTypeThree()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsFive_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndExpectedTypeIsNotFive_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFive).Value().Should().BeOfTypeFour()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsSix_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndExpectedTypeIsNotSix_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSix).Value().Should().BeOfTypeFive()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsSeven_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSeven()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndExpectedTypeIsNotSeven_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSix()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsEightAndExpectedTypeIsEight_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelEight).Value().Should().BeOfTypeEight()
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsEightAndExpectedTypeIsNotEight_Then_ShouldThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelEight).Value().Should().BeOfTypeSeven()
			).Should().Throw<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelOne).Value().Should().BeOfTypeOne().AndValue.Should().Be(ModelOne)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelTwo).Value().Should().BeOfTypeTwo().AndValue.Should().Be(ModelTwo)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelThree).Value().Should().BeOfTypeThree().AndValue.Should().Be(ModelThree)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFourAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFour).Value().Should().BeOfTypeFour().AndValue.Should().Be(ModelFour)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsFiveAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelFive).Value().Should().BeOfTypeFive().AndValue.Should().Be(ModelFive)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSixAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSix).Value().Should().BeOfTypeSix().AndValue.Should().Be(ModelSix)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsSevenAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelSeven).Value().Should().BeOfTypeSeven().AndValue.Should().Be(ModelSeven)
			).Should().NotThrow();

			[Fact]
			public void When_TypeIsEightAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Action(() =>
				Union.FromDefinition<EightDefinition>().Create(ModelEight).Value().Should().BeOfTypeEight().AndValue.Should().Be(ModelEight)
			).Should().NotThrow();
		}
	}
}
