using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class ResultTypeAssertionsExtensionsTests
	{
		public class SuccessChecks
		{
			private const int VALUE = 3;

			[Fact]
			public void ShouldNotThrowAsyncException() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, Exception>(VALUE))
					.Should()
					.BeSuccessful("an exception occurred"))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowAsyncExceptionWhenAdditionalAssertionSucceeds() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, Exception>(VALUE))
					.Should()
					.BeSuccessful()
					.AndSuccessValue(value => value.Should().Be(VALUE)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() => Task.FromResult(Result.Failure<int, Exception>(new Exception())).Should().BeSuccessful()).Should().ThrowAsync<Exception>();
		}

		public class FailureChecks
		{
			private const string VALUE = "value";

			[Fact]
			public void ShouldNotThrowAsyncException() => new Func<Task>(() =>
				Task.FromResult(Result.Failure<int, Exception>(new Exception(VALUE)))
					.Should()
					.BeFaulted())
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowAsyncExceptionWhenAdditionalAssertionSucceeds() => new Func<Task>(() =>
				Task.FromResult(Result.Failure<int, Exception>(new Exception(VALUE)))
					.Should()
					.BeFaulted()
					.AndFailureValue(failure => failure.Should().Match<Exception>(ex => ex.Message == VALUE)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, Exception>(3))
					.Should()
					.BeFaulted())
					.Should().ThrowAsync<Exception>();
		}

		public class EqualityChecks
		{
			[Fact]
			public void ShouldNotThrowAsyncExceptionWhenBothSuccessAndBothHaveSameSuccessValues() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, string>(1337))
					.Should()
					.Be(Result.Success<int, string>(1337)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowAsyncExceptionWhenBothFaultedAndBothHaveSameFailureValues() => new Func<Task>(() =>
				Task.FromResult(Result.Failure<int, string>("error"))
					.Should()
					.Be(Result.Failure<int, string>("error")))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowExceptionWhenBothSuccessButHaveDifferentSuccessValues() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, string>(3))
					.Should()
					.Be(Result.Success<int, string>(4)))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenBothFaultedButHaveDifferentFailureValues() => new Func<Task>(() =>
				Task.FromResult(Result.Failure<int, string>("1"))
					.Should()
					.Be(Result.Failure<int, string>("2")))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSuccessAndRightIsFaulted() => new Func<Task>(() =>
				Task.FromResult(Result.Success<int, string>(3))
					.Should()
					.Be(Result.Failure<int, string>("e")))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsFaultedAndRightIsSuccess() => new Func<Task>(() =>
				Task.FromResult(Result.Failure<int, string>("e"))
					.Should()
					.Be(Result.Success<int, string>(3)))
					.Should().ThrowAsync<Exception>();
		}
	}
}
