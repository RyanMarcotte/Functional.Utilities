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
				private const int VALUE = 3;

				[Fact]
				public void ShouldNotThrowException() => new Action(() =>
				{
					Option.Some(VALUE)
						.Should()
						.HaveValue();

				}).Should().NotThrow();

				[Fact]
				public void ShouldNotThrowExceptionWhenAdditionalAssertionSucceeds() => new Action(() =>
				{
					Option.Some(VALUE)
						.Should()
						.HaveValue()
						.AndValue
						.Should()
						.Be(VALUE);

				}).Should().NotThrow();

				[Fact]
				public void ShouldThrowException() => new Action(() =>
				{
					Option.None<int>()
						.Should()
						.HaveValue();

				}).Should().Throw<Exception>();
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
