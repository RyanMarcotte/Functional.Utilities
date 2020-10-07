using System;
using System.Linq;
using FluentAssertions;
using Functional.SerilogExtensions.Tests._Infrastructure;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Functional.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		public class ResultDestructurePolicyTests : IDisposable
		{
			private const int SUCCESS_VALUE = 1337;
			private const string FAILURE_VALUE = "something went wrong";

			private readonly ILogger _logger;
			private readonly ITestCorrelatorContext _context;

			public ResultDestructurePolicyTests()
			{
				var configuration = new ResultDestructurePolicyConfiguration(
					success => new { IsSuccessful = true, Data = success },
					failure => new { IsSuccessful = false, Data = failure });

				_logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					.Destructure.With(new ResultDestructurePolicy(configuration))
					.CreateLogger();

				_context = TestCorrelator.CreateContext();
			}

			[Theory]
			[SuccessfulResultOfPrimitiveType]
			[SuccessfulResultOfComplexType]
			[ClassContainingSuccessfulResultOfPrimitiveType]
			[ClassContainingSuccessfulResultOfComplexType]
			public void WriteSuccessfulResult(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{@{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().ContainAll("IsSuccessful: True", SUCCESS_VALUE.ToString()));
			}

			[Theory]
			[FaultedResultOfPrimitiveType]
			[FaultedResultOfComplexType]
			[ClassContainingFaultedResultOfPrimitiveType]
			[ClassContainingFaultedResultOfComplexType]
			public void WriteFaultedResult(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{@{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().ContainAll("IsSuccessful: False", FAILURE_VALUE));
			}

			public void Dispose()
			{
				_context.Dispose();
			}

			#region Arrangements

			private class SuccessfulResultOfPrimitiveType : SingleParameterArrangement
			{
				public SuccessfulResultOfPrimitiveType()
					: base(Result.Success<int, string>(SUCCESS_VALUE))
				{
				}
			}

			private class FaultedResultOfPrimitiveType : SingleParameterArrangement
			{
				public FaultedResultOfPrimitiveType()
					: base(Result.Failure<int, string>(FAILURE_VALUE))
				{
				}
			}

			private class SuccessfulResultOfComplexType : SingleParameterArrangement
			{
				public SuccessfulResultOfComplexType()
					: base(Result.Success<Money, string>(new Money(SUCCESS_VALUE)))
				{
				}
			}

			private class FaultedResultOfComplexType : SingleParameterArrangement
			{
				public FaultedResultOfComplexType()
					: base(Result.Failure<int, Error>(new Error(FAILURE_VALUE)))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfPrimitiveType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfPrimitiveType()
					: base(new ClassWithSimpleResult(Result.Success<int, string>(SUCCESS_VALUE)))
				{
				}
			}

			private class ClassContainingFaultedResultOfPrimitiveType : SingleParameterArrangement
			{
				public ClassContainingFaultedResultOfPrimitiveType()
					: base(new ClassWithSimpleResult(Result.Failure<int, string>(FAILURE_VALUE)))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfComplexType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfComplexType()
					: base(new ClassWithComplexResult(Result.Success<Money, Error>(new Money(SUCCESS_VALUE))))
				{
				}
			}

			private class ClassContainingFaultedResultOfComplexType : SingleParameterArrangement
			{
				public ClassContainingFaultedResultOfComplexType()
					: base(new ClassWithComplexResult(Result.Failure<Money, Error>(new Error(FAILURE_VALUE))))
				{
				}
			}

			#endregion

			#region Models

			private class ClassWithSimpleResult
			{
				public ClassWithSimpleResult(Result<int, string> value)
				{
					Value = value;
				}

				public Result<int, string> Value { get; }
			}

			private class ClassWithComplexResult
			{
				public ClassWithComplexResult(Result<Money, Error> value)
				{
					Value = value;
				}

				public Result<Money, Error> Value { get; }
			}

			#endregion
		}
	}
}