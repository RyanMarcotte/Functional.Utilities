using System;
using FluentAssertions;
using Xunit;

namespace Functional.Primitives.FluentAssertions.Tests
{
	public class OptionTypeAssertionsTests
	{
		public class ValueChecks
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
			public void ShouldThrowExceptionWithNameOfVariable()
			{
				var localVariable = Option.None<int>();
				new Action(() => localVariable.Should().HaveValue())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMember()
			{
				var envelope = new OptionEnvelope<int>(Option.None<int>());
				new Action(() => envelope.Data.Should().HaveValue())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<int>.Data));
			}
		}

		public class NoValueChecks
		{
			[Fact]
			public void ShouldNotThrowException() => new Action(() => Option.None<int>().Should().NotHaveValue()).Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariable()
			{
				var localVariable = Option.Some(3);
				new Action(() => localVariable.Should().NotHaveValue())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMember()
			{
				var envelope = new OptionEnvelope<int>(Option.Some(15));
				new Action(() => envelope.Data.Should().NotHaveValue())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<int>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithCustomOutput()
			{
				const int ID = 1337;
				const string NAME = "TEST";

				var result = Option.Some(new DummyModel(ID, NAME));
				new Action(() => result.Should().NotHaveValue(m => $"[{m.ID}] {m.Name}"))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll($"[{ID}]", NAME);
			}

			#region Models

			private class DummyModel
			{
				public DummyModel(int id, string name)
				{
					ID = id;
					Name = name;
				}

				public int ID { get; }
				public string Name { get; }
			}

			#endregion
		}

		public class IntegerOptionChecks
		{
			private const int VALUE = 54;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Action(() =>
			{
				Option.Some(VALUE)
					.Should()
					.Be(Option.Some(VALUE));
			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Action(() =>
			{
				Option.None<int>()
					.Should()
					.Be(Option.None<int>());
			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenBothSomeButDifferentValues()
			{
				var localVariable = Option.Some(VALUE);
				new Action(() => localVariable.Should().Be(Option.Some(VALUE + 1)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenBothSomeButDifferentValues()
			{
				var envelope = new OptionEnvelope<int>(Option.Some(VALUE));
				new Action(() => envelope.Data.Should().Be(Option.Some(VALUE + 1)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<int>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenLeftIsSomeButRightIsNone()
			{
				var localVariable = Option.Some(VALUE);
				new Action(() => localVariable.Should().Be(Option.None<int>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsSomeButRightIsNone()
			{
				var envelope = new OptionEnvelope<int>(Option.Some(VALUE));
				new Action(() => envelope.Data.Should().Be(Option.None<int>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<int>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenLeftIsNoneButRightIsSome()
			{
				var localVariable = Option.None<int>();
				new Action(() => localVariable.Should().Be(Option.Some(VALUE)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsNoneButRightIsSome()
			{
				var envelope = new OptionEnvelope<int>(Option.None<int>());
				new Action(() => envelope.Data.Should().Be(Option.Some(VALUE)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(envelope), nameof(OptionEnvelope<int>.Data));
			}
		}

		public class StringOptionChecks
		{
			private const string VALUE = "test";

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Action(() =>
			{
				Option.Some(VALUE)
					.Should()
					.Be(Option.Some(VALUE));
			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Action(() =>
			{
				Option.None<string>()
					.Should()
					.Be(Option.None<string>());
			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenBothSomeButDifferentValues()
			{
				var localVariable = Option.Some(VALUE);
				new Action(() => localVariable.Should().Be(Option.Some(VALUE + 1)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenBothSomeButDifferentValues()
			{
				var envelope = new OptionEnvelope<string>(Option.Some(VALUE));
				new Action(() => envelope.Should().Be(Option.Some(VALUE + 1)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<string>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenLeftIsSomeButRightIsNone()
			{
				var localVariable = Option.Some(VALUE);
				new Action(() => localVariable.Should().Be(Option.None<string>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsSomeButRightIsNone()
			{
				var envelope = new OptionEnvelope<string>(Option.Some(VALUE));
				new Action(() => envelope.Should().Be(Option.None<string>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<string>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfVariableWhenLeftIsNoneButRightIsSome()
			{
				var localVariable = Option.None<string>();
				new Action(() => localVariable.Should().Be(Option.Some(VALUE)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsNoneButRightIsSome()
			{
				var envelope = new OptionEnvelope<string>(Option.None<string>());
				new Action(() => envelope.Should().Be(Option.Some(VALUE)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<string>.Data));
			}
		}

		public class EquatableClassOptionChecks
		{
			private const int VALUE = 1337;

			[Fact]
			public void ShouldNotThrowExceptionWhenBothSomeAndSameValues() => new Action(() =>
			{
				Option.Some(new EquatableClass(VALUE))
					.Should()
					.Be(Option.Some(new EquatableClass(VALUE)));
			}).Should().NotThrow();

			[Fact]
			public void ShouldNotThrowExceptionWhenBothNone() => new Action(() =>
			{
				Option.None<string>()
					.Should()
					.Be(Option.None<string>());
			}).Should().NotThrow();

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenBothSomeButDifferentValues()
			{
				var localVariable = Option.Some(new EquatableClass(VALUE));
				new Action(() => localVariable.Should().Be(Option.Some(new EquatableClass(VALUE + 1))))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenBothSomeButDifferentValues()
			{
				var envelope = new OptionEnvelope<EquatableClass>(Option.Some(new EquatableClass(VALUE)));
				new Action(() => envelope.Data.Should().Be(Option.Some(new EquatableClass(VALUE + 1))))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<EquatableClass>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenLeftIsSomeButRightIsNone()
			{
				var localVariable = Option.Some(new EquatableClass(VALUE));
				new Action(() => localVariable.Should().Be(Option.None<EquatableClass>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsSomeButRightIsNone()
			{
				var envelope = new OptionEnvelope<EquatableClass>(Option.Some(new EquatableClass(VALUE)));
				new Action(() => envelope.Data.Should().Be(Option.None<EquatableClass>()))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<EquatableClass>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenLeftIsNoneButRightIsSome()
			{
				var localVariable = Option.None<EquatableClass>();
				new Action(() => localVariable.Should().Be(Option.Some(new EquatableClass(VALUE))))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsNoneButRightIsSome()
			{
				var envelope = new OptionEnvelope<EquatableClass>(Option.None<EquatableClass>());
				new Action(() => envelope.Data.Should().Be(Option.Some(new EquatableClass(VALUE))))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(OptionEnvelope<EquatableClass>.Data));
			}

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

		private class OptionEnvelope<T>
		{
			public OptionEnvelope(Option<T> data)
			{
				Data = data;
			}

			public Option<T> Data { get; }
		}
	}
}
