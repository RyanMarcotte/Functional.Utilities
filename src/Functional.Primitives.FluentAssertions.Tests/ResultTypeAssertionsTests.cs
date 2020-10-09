using System;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class ResultTypeAssertionsTests
	{
		public class SuccessChecks
		{
			private const int VALUE = 3;

			[Fact]
			public void ShouldNotThrowException() => new Action(() =>
			{
				Result.Success<int, Exception>(VALUE)
					.Should()
					.BeSuccessful("an exception occurred");

			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenAdditionalAssertionSucceeds() => new Action(() =>
			{
				Result.Success<int, Exception>(VALUE)
					.Should()
					.BeSuccessful()
					.AndSuccessValue
					.Should()
					.Be(VALUE);

			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowException() => new Action(() => Result.Failure<int, Exception>(new Exception()).Should().BeSuccessful()).Should().Throw<Exception>();
		}

		public class FailureChecks
		{
			private const string VALUE = "value";

			[Fact]
			public void ShouldNotThrowException() => new Action(() =>
			{
				Result.Failure<int, Exception>(new Exception(VALUE))
					.Should()
					.BeFaulted();

			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenAdditionalAssertionSucceeds() => new Action(() =>
			{
				Result.Failure<int, Exception>(new Exception(VALUE))
					.Should()
					.BeFaulted()
					.AndFailureValue
					.Should()
					.Match<Exception>(ex => ex.Message == VALUE);

			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowException() => new Action(() =>
			{
				Result.Success<int, Exception>(3)
					.Should()
					.BeFaulted();

			}).Should().Throw<Exception>();
		}

		public class EqualityChecks
		{
			[Fact]
			public void ShouldNotThrowExceptionWhenBothSuccessAndBothHaveSameSuccessValues() => new Action(() =>
			{
				Result.Success<int, string>(1337)
					.Should()
					.Be(Result.Success<int, string>(1337));
			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothFaultedAndBothHaveSameFailureValues() => new Action(() =>
			{
				Result.Failure<int, string>("error")
					.Should()
					.Be(Result.Failure<int, string>("error"));
			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWhenBothSuccessButHaveDifferentSuccessValues() => new Action(() =>
			{
				Result.Success<int, string>(3)
					.Should()
					.Be(Result.Success<int, string>(4));

			}).Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenBothFaultedButHaveDifferentFailureValues() => new Action(() =>
			{
				Result.Failure<int, string>("1")
					.Should()
					.Be(Result.Failure<int, string>("2"));

			}).Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSuccessAndRightIsFaulted() => new Action(() =>
			{
				Result.Success<int, string>(3)
					.Should()
					.Be(Result.Failure<int, string>("e"));

			}).Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsFaultedAndRightIsSuccess() => new Action(() =>
			{
				Result.Failure<int, string>("e")
					.Should()
					.Be(Result.Success<int, string>(3));

			}).Should().Throw<Exception>();
		}
	}
}
