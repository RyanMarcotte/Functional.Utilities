using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class OptionTypeAssertionsExtensionsTests
	{
		public class ValueChecks
		{
			private const int VALUE = 3;

			[Fact]
			public void ShouldNotThrowException() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.HaveValue())
			.Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenAdditionalAssertionSucceeds() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.HaveValue()
					.AndValue(value => value.Should().Be(VALUE)))
			.Should().NotThrow();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.HaveValue())
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenAdditionalAssertionFails() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.HaveValue()
					.AndValue(value => value.Should().Be(VALUE)))
			.Should().NotThrow();
		}

		public class NoValueChecks
		{
			[Fact]
			public void ShouldNotThrowException() => new Func<Task>(() => Task.FromResult(Option.None<int>()).Should().NotHaveValue()).Should().NotThrow();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() => Task.FromResult(Option.Some(3)).Should().NotHaveValue()).Should().Throw<Exception>();
		}

		public class IntegerOptionChecks
		{
			private const int VALUE = 54;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE)))
			.Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.Be(Option.None<int>()))
			.Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE+1)))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.None<int>()))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.Be(Option.Some(VALUE)))
			.Should().Throw<Exception>();
		}

		public class StringOptionChecks
		{
			private const string VALUE = "test";

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE)))
			.Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.None<string>()))
			.Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE + 1)))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.None<string>()))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.Some(VALUE)))
			.Should().Throw<Exception>();
		}

		public class EquatableClassOptionChecks
		{
			private const int VALUE = 1337;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE))))
			.Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.None<string>()))
			.Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE + 1))))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.None<EquatableClass>()))
			.Should().Throw<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<EquatableClass>())
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE))))
			.Should().Throw<Exception>();

			#region Models

			private class EquatableClass : IEquatable<EquatableClass>
			{
				public EquatableClass(int value)
				{
					Value = value;
				}

				public int Value { get; }

				public bool Equals(EquatableClass other)
				{
					if (other is null) return false;
					if (ReferenceEquals(this, other)) return true;
					return Value == other.Value;
				}

				public override bool Equals(object obj)
				{
					if (obj is null) return false;
					if (ReferenceEquals(this, obj)) return true;
					return obj.GetType() == GetType() && Equals((EquatableClass)obj);
				}

				public override int GetHashCode() => Value;
				public static bool operator ==(EquatableClass left, EquatableClass right) => Equals(left, right);
				public static bool operator !=(EquatableClass left, EquatableClass right) => !Equals(left, right);
			}

			#endregion
		}
	}
}
