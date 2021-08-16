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
			public void ShouldThrowExceptionWithNameOfLocalVariable()
			{
				var localVariable = Result.Failure<int, Exception>(new Exception());
				new Action(() => localVariable.Should().BeSuccessful())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMember()
			{
				var envelope = new ResultEnvelope<int, Exception>(Result.Failure<int, Exception>(new Exception()));
				new Action(() => envelope.Data.Should().BeSuccessful())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(ResultEnvelope<int, Exception>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithCustomOutput()
			{
				const int ID = 1337;
				const string NAME = "TEST";

				var result = Result.Failure<int, DummyModel>(new DummyModel(ID, NAME));
				new Action(() => result.Should().BeSuccessful(m => $"[{m.ID}] {m.Name}"))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll($"[{ID}]", NAME);
			}
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
			public void ShouldThrowExceptionWithNameOfLocalVariable()
			{
				var localVariable = Result.Success<int, Exception>(3);
				new Action(() => localVariable.Should().BeFaulted())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMember()
			{
				var envelope = new ResultEnvelope<int, Exception>(Result.Success<int, Exception>(3));
				new Action(() => envelope.Data.Should().BeFaulted())
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(ResultEnvelope<int, Exception>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithCustomOutput()
			{
				const int ID = 1337;
				const string NAME = "TEST";

				var result = Result.Success<DummyModel, string>(new DummyModel(ID, NAME));
				new Action(() => result.Should().BeFaulted(m => $"[{m.ID}] {m.Name}"))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll($"[{ID}]", NAME);
			}
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
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenBothSuccessButHaveDifferentSuccessValues()
			{
				var localVariable = Result.Success<int, string>(3);
				new Action(() => localVariable.Should().Be(Result.Success<int, string>(4)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenBothSuccessButHaveDifferentSuccessValues()
			{
				var envelope = new ResultEnvelope<int, string>(Result.Success<int, string>(3));
				new Action(() => envelope.Data.Should().Be(Result.Success<int, string>(4)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().ContainAll(nameof(envelope), nameof(ResultEnvelope<int, Exception>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenBothFaultedButHaveDifferentFailureValues()
			{
				var localVariable = Result.Failure<int, string>("1");
				new Action(() => localVariable.Should().Be(Result.Failure<int, string>("2")))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenBothFaultedButHaveDifferentFailureValues()
			{
				var envelope = new ResultEnvelope<int, string>(Result.Failure<int, string>("1"));
				new Action(() => envelope.Data.Should().Be(Result.Failure<int, string>("2")))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(envelope), nameof(ResultEnvelope<int, string>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenLeftIsSuccessAndRightIsFaulted()
			{
				var localVariable = Result.Success<int, string>(3);
				new Action(() => localVariable.Should().Be(Result.Failure<int, string>("e")))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsSuccessAndRightIsFaulted()
			{
				var envelope = new ResultEnvelope<int, string>(Result.Success<int, string>(3));
				new Action(() => envelope.Data.Should().Be(Result.Failure<int, string>("e")))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(envelope), nameof(ResultEnvelope<int, string>.Data));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfLocalVariableWhenLeftIsFaultedAndRightIsSuccess()
			{
				var localVariable = Result.Failure<int, string>("e");
				new Action(() => localVariable.Should().Be(Result.Success<int, string>(3)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(localVariable));
			}

			[Fact]
			public void ShouldThrowExceptionWithNameOfClassMemberWhenLeftIsFaultedAndRightIsSuccess()
			{
				var envelope = new ResultEnvelope<int, string>(Result.Failure<int, string>("e"));
				new Action(() => envelope.Data.Should().Be(Result.Success<int, string>(3)))
					.Should()
					.Throw<Exception>()
					.And.Message.Should().Contain(nameof(envelope), nameof(ResultEnvelope<int, string>.Data));
			}
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

		private class ResultEnvelope<TSuccess, TFailure>
		{
			public ResultEnvelope(Result<TSuccess, TFailure> data)
			{
				Data = data;
			}

			public Result<TSuccess, TFailure> Data { get; }
		}

		#endregion
	}
}
