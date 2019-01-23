using System;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class ResultTypeAssertionsTests
	{
		public class SuccessChecks
		{
			public class WithNoSpecialAssertions
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Success<int, Exception>(3).Should().BeSuccessful()).Should().NotThrow();

				[Fact]
				public void ShouldThrowException() => new Action(() => Result.Failure<int, Exception>(new Exception()).Should().BeSuccessful()).Should().Throw<Exception>();
			}

			public class WithExpectedValueAssertion
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Success<int, Exception>(3).Should().BeSuccessfulWithExpectedValue(3)).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfNotExpectedSuccessValue() => new Action(() => Result.Success<int, Exception>(2).Should().BeSuccessfulWithExpectedValue(30)).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfFaultedResult() => new Action(() => Result.Failure<int, Exception>(new Exception()).Should().BeSuccessfulWithExpectedValue(3)).Should().Throw<Exception>();
			}

			public class WithAssertionsToMatchProperties
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Success<int, Exception>(3).Should().BeSuccessful(value => value.Should().BeGreaterOrEqualTo(0))).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfNoMatchingSuccessValue() => new Action(() => Result.Success<int, Exception>(3).Should().BeSuccessful(value => value.Should().BeLessOrEqualTo(0))).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfFaultedResult() => new Action(() => Result.Failure<int, Exception>(new Exception()).Should().BeSuccessful(value => value.Should().Be(0))).Should().Throw<Exception>();
			}
		}

		public class FailureChecks
		{
			public class WithNoSpecialAssertions
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Failure<int, Exception>(new Exception()).Should().BeFaulted()).Should().NotThrow();

				[Fact]
				public void ShouldThrowException() => new Action(() => Result.Success<int, Exception>(3).Should().BeFaulted()).Should().Throw<Exception>();
			}

			public class WithExpectedValueAssertion
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Failure<int, string>(string.Empty).Should().BeFaultedWithExpectedValue(string.Empty)).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfNotExpectedFailureValue() => new Action(() => Result.Failure<int, string>(string.Empty).Should().BeFaultedWithExpectedValue("not empty")).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfSuccessfulResult() => new Action(() => Result.Success<int, string>(3).Should().BeFaultedWithExpectedValue(string.Empty)).Should().Throw<Exception>();
			}

			public class WithAssertionsToMatchProperties
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Result.Failure<string, int>(3).Should().BeFaulted(value => value.Should().BeGreaterOrEqualTo(0))).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfNoMatchingSuccessValue() => new Action(() => Result.Failure<string, int>(3).Should().BeFaulted(value => value.Should().BeLessOrEqualTo(0))).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfFaultedResult() => new Action(() => Result.Success<string, int>(string.Empty).Should().BeFaulted(value => value.Should().Be(0))).Should().Throw<Exception>();
			}
		}
	}
}
