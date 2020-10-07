using System;
using System.Linq;
using Functional.SerilogExtensions.Tests._Infrastructure;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Functional.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		public class WeirdDestructurePolicyTests : IDisposable
		{
			private readonly ILogger _logger;
			private readonly ITestCorrelatorContext _context;

			public WeirdDestructurePolicyTests()
			{
				var optionConfiguration = new OptionDestructurePolicyConfiguration(value => value, () => "NONE");
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
			[OptionOfOption]
			[ResultOfResult]
			public void Writes(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{@{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainsSingleWithProperty(PROPERTY_KEY);
			}

			public void Dispose()
			{
				_context.Dispose();
			}

			#region Arrangements

			private class OptionOfOption : SingleParameterArrangement
			{
				public OptionOfOption()
					: base(Option.Some(Option.Some(1337)))
				{
				}
			}

			private class ResultOfResult : SingleParameterArrangement
			{
				public ResultOfResult()
					: base(Result.Success<Result<int, string>, Exception>(Result.Success<int, string>(1337)))
				{
				}
			}

			#endregion
		}
	}
}