using System;
using System.Linq;
using FluentAssertions;
using Functional.Primitives.SerilogExtensions.Tests._Infrastructure;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Functional.Primitives.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		// https://xunit.net/docs/shared-context#constructor
		public class OptionAndResultDestructurePolicyTests : IDisposable
		{
			private const int SUCCESS_VALUE = 1337;
			private const string NO_VALUE = "NONE";

			private readonly ILogger _logger;
			private readonly ITestCorrelatorContext _context;

			public OptionAndResultDestructurePolicyTests()
			{
				var optionConfiguration = new OptionDestructurePolicyConfiguration(value => value, () => NO_VALUE);
				var resultConfiguration = new ResultDestructurePolicyConfiguration(
					success => new { IsSuccessful = true, Data = success },
					failure => new { IsSuccessful = false, Data = failure });

				_logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					.Destructure.FunctionalOptionAndResultTypes(optionConfiguration, resultConfiguration)
					.CreateLogger();

				_context = TestCorrelator.CreateContext();
			}

			[Theory]
			[SuccessfulResultOfOptionSomePrimitiveType]
			[SuccessfulResultOfOptionSomeComplexType]
			[ClassContainingSuccessfulResultOfOptionSomePrimitiveType]
			[ClassContainingSuccessfulResultOfOptionSomeComplexType]
			public void WritesSuccessfulResultOfOptionSome(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{@{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().ContainAll("IsSuccessful: True", SUCCESS_VALUE.ToString()));
			}

			[Theory]
			[SuccessfulResultOfOptionNonePrimitiveType]
			[SuccessfulResultOfOptionNoneComplexType]
			[ClassContainingSuccessfulResultOfOptionNonePrimitiveType]
			[ClassContainingSuccessfulResultOfOptionNoneComplexType]
			public void WritesSuccessfulResultOfOptionNone(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{@{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().ContainAll("IsSuccessful: True", NO_VALUE));
			}

			public void Dispose()
			{
				_context.Dispose();
			}

			#region Arrangements

			private class SuccessfulResultOfOptionSomePrimitiveType : SingleParameterArrangement
			{
				public SuccessfulResultOfOptionSomePrimitiveType()
					: base(Result.Success<Option<int>, string>(Option.Some(SUCCESS_VALUE)))
				{
				}
			}

			private class SuccessfulResultOfOptionNonePrimitiveType : SingleParameterArrangement
			{
				public SuccessfulResultOfOptionNonePrimitiveType()
					: base(Result.Success<Option<int>, string>(Option.None<int>()))
				{
				}
			}

			private class SuccessfulResultOfOptionSomeComplexType : SingleParameterArrangement
			{
				public SuccessfulResultOfOptionSomeComplexType()
					: base(Result.Success<Option<Money>, string>(Money.CreateOption(SUCCESS_VALUE)))
				{
				}
			}

			private class SuccessfulResultOfOptionNoneComplexType : SingleParameterArrangement
			{
				public SuccessfulResultOfOptionNoneComplexType()
					: base(Result.Success<Option<Money>, string>(Money.CreateOption(null)))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfOptionSomePrimitiveType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfOptionSomePrimitiveType()
					: base(new ClassWithResultOfSimpleOption(Result.Success<Option<int>, string>(Option.Some(SUCCESS_VALUE))))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfOptionNonePrimitiveType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfOptionNonePrimitiveType()
					: base(new ClassWithResultOfSimpleOption(Result.Success<Option<int>, string>(Option.None<int>())))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfOptionSomeComplexType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfOptionSomeComplexType()
					: base(new ClassWithResultOfComplexOption(Result.Success<Option<Money>, string>(Money.CreateOption(SUCCESS_VALUE))))
				{
				}
			}

			private class ClassContainingSuccessfulResultOfOptionNoneComplexType : SingleParameterArrangement
			{
				public ClassContainingSuccessfulResultOfOptionNoneComplexType()
					: base(new ClassWithResultOfComplexOption(Result.Success<Option<Money>, string>(Money.CreateOption(null))))
				{
				}
			}

			#endregion

			#region Models

			private class ClassWithResultOfSimpleOption
			{
				public ClassWithResultOfSimpleOption(Result<Option<int>, string> value)
				{
					Value = value;
				}

				public Result<Option<int>, string> Value { get; }
			}

			private class ClassWithResultOfComplexOption
			{
				public ClassWithResultOfComplexOption(Result<Option<Money>, string> value)
				{
					Value = value;
				}

				public Result<Option<Money>, string> Value { get; }
			}

			#endregion
		}
	}
}