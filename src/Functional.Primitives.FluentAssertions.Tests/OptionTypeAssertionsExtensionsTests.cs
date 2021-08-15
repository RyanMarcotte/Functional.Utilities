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
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowExceptionWhenAdditionalAssertionSucceeds() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.HaveValue()
					.AndValue(value => value.Should().Be(VALUE)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.HaveValue())
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenAdditionalAssertionFails() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.HaveValue()
					.AndValue(value => value.Should().Be(VALUE)))
					.Should().NotThrowAsync();
		}

		public class NoValueChecks
		{
			[Fact]
			public void ShouldNotThrowException() => new Func<Task>(() => Task.FromResult(Option.None<int>()).Should().NotHaveValue()).Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowException() => new Func<Task>(() => Task.FromResult(Option.Some(3)).Should().NotHaveValue()).Should().ThrowAsync<Exception>();
		}

		public class IntegerOptionChecks
		{
			private const int VALUE = 54;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.Be(Option.None<int>()))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE+1)))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.None<int>()))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<int>())
					.Should()
					.Be(Option.Some(VALUE)))
					.Should().ThrowAsync<Exception>();
		}

		public class StringOptionChecks
		{
			private const string VALUE = "test";

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE)))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.None<string>()))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.Some(VALUE + 1)))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(VALUE))
					.Should()
					.Be(Option.None<string>()))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.Some(VALUE)))
					.Should().ThrowAsync<Exception>();
		}

		public class EquatableClassOptionChecks
		{
			private const int VALUE = 1337;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE))))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Func<Task>(() =>
				Task.FromResult(Option.None<string>())
					.Should()
					.Be(Option.None<string>()))
					.Should().NotThrowAsync();

			[Fact]
			public void ShouldThrowExceptionWhenBothSomeButDifferentValues() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE + 1))))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsSomeButRightIsNone() => new Func<Task>(() =>
				Task.FromResult(Option.Some(new EquatableClass(VALUE)))
					.Should()
					.Be(Option.None<EquatableClass>()))
					.Should().ThrowAsync<Exception>();

			[Fact]
			public void ShouldThrowExceptionWhenLeftIsNoneButRightIsSome() => new Func<Task>(() =>
				Task.FromResult(Option.None<EquatableClass>())
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE))))
					.Should().ThrowAsync<Exception>();

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
