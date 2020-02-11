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
	}
}
