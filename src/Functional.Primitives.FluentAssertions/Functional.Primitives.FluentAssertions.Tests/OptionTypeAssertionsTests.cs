using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class OptionTypeAssertionsTests
	{
		public class ValueChecks
		{
			public class WithNoSpecialAssertions
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Option.Some(3).Should().HaveValue()).Should().NotThrow();

				[Fact]
				public void ShouldThrowException() => new Action(() => Option.None<int>().Should().HaveValue()).Should().Throw<Exception>();
			}

			public class WithExpectedValueAssertion
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Option.Some(3).Should().HaveExpectedValue(3)).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfUnexpectedValue() => new Action(() => Option.Some(3).Should().HaveExpectedValue(0)).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfNoValue() => new Action(() => Option.None<int>().Should().HaveExpectedValue(0)).Should().Throw<Exception>();
			}

			public class WithAssertionsToMatchProperties
			{
				[Fact]
				public void ShouldNotThrowException() => new Action(() => Option.Some(3).Should().HaveValue(value => value.Should().BeGreaterOrEqualTo(0))).Should().NotThrow();

				[Fact]
				public void ShouldThrowExceptionIfNoMatchingValue() => new Action(() => Option.Some(3).Should().HaveValue(value => value.Should().BeLessOrEqualTo(0))).Should().Throw<Exception>();

				[Fact]
				public void ShouldThrowExceptionIfNoValue() => new Action(() => Option.None<int>().Should().HaveValue(value => value.Should().Be(0))).Should().Throw<Exception>();
			}
		}

		public class NoValueChecks
		{
			[Fact]
			public void ShouldNotThrowException() => new Action(() => Option.None<int>().Should().NotHaveValue()).Should().NotThrow();

			[Fact]
			public void ShouldThrowException() => new Action(() => Option.Some(3).Should().NotHaveValue()).Should().Throw<Exception>();
		}
	}
}
