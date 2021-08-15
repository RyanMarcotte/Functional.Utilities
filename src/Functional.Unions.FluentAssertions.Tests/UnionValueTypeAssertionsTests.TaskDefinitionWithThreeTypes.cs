using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Unions.FluentAssertions.Tests
{
	public partial class UnionValueTypeAssertionsTests
	{
		public class TaskDefinitionWithThreeTypes
		{
			[Fact]
			public void When_EqualityIsTrue_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelThree)).Value().Should().Be(Union.FromDefinition<ThreeDefinition>().Create(ModelThree).Value())
			).Should().NotThrowAsync();

			[Fact]
			public void When_EqualityIsFalse_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelThree)).Value().Should().Be(Union.FromDefinition<ThreeDefinition>().Create(new ClassThree()).Value())
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsOne_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelOne)).Value().Should().BeOfTypeOne()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsOneAndExpectedTypeIsNotOne_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelOne)).Value().Should().BeOfTypeTwo()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsTwo_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelTwo)).Value().Should().BeOfTypeTwo()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsTwoAndExpectedTypeIsNotTwo_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelTwo)).Value().Should().BeOfTypeOne()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsThree_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelThree)).Value().Should().BeOfTypeThree()
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsThreeAndExpectedTypeIsNotThree_Then_ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelThree)).Value().Should().BeOfTypeTwo()
			).Should().ThrowAsync<Exception>();

			[Fact]
			public void When_TypeIsOneAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelOne)).Value().Should().BeOfTypeOne().AndValue(value => value.Should().Be(ModelOne))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsTwoAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelTwo)).Value().Should().BeOfTypeTwo().AndValue(value => value.Should().Be(ModelTwo))
			).Should().NotThrowAsync();

			[Fact]
			public void When_TypeIsThreeAndAdditionalAssertionSucceeds_Then_ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Union.FromDefinition<ThreeDefinition>().Create(ModelThree)).Value().Should().BeOfTypeThree().AndValue(value => value.Should().Be(ModelThree))
			).Should().NotThrowAsync();
		}
	}
}
