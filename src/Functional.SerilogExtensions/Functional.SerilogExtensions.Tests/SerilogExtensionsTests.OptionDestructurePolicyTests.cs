using System.IO;
using System.Linq;
using FluentAssertions;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Functional.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		public class OptionDestructurePolicyTests
		{
			[Fact]
			public void WriteOptionContainsPrimitiveType()
			{
				const int AMOUNT = 1337;

				var logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					//.Destructure.With(new OptionDestructurePolicy())
					.CreateLogger();

				using var context = TestCorrelator.CreateContext();

				logger.Information("{PAYLOAD}", Option.Some(AMOUNT));
				var logEventCollection = TestCorrelator.GetLogEventsFromContextGuid(context.Guid).ToArray();

				logEventCollection.Should().ContainSingle();
				foreach (var logEvent in logEventCollection)
				{
					using var writer = new StringWriter();
					logEvent.Properties["PAYLOAD"].Render(writer);

					writer.Flush();
					writer.ToString().Should().Contain(AMOUNT.ToString());
				}
			}

			[Fact]
			public void WriteOptionOfComplexType()
			{
				const int AMOUNT = 1337;

				var logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					//.Destructure.With(new OptionDestructurePolicy())
					.CreateLogger();

				using var context = TestCorrelator.CreateContext();

				logger.Information("{PAYLOAD}", Money.CreateOption(AMOUNT));
				var logEventCollection = TestCorrelator.GetLogEventsFromContextGuid(context.Guid).ToArray();

				logEventCollection.Should().ContainSingle();
				foreach (var logEvent in logEventCollection)
				{
					using var writer = new StringWriter();
					logEvent.Properties["PAYLOAD"].Render(writer);

					writer.Flush();
					writer.ToString().Should().Contain(AMOUNT.ToString());
				}
			}

			[Fact]
			public void WriteClassContainingOptionOfComplexType()
			{
				const int AMOUNT = 1337;

				var logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					//.Destructure.With(new OptionDestructurePolicy())
					.CreateLogger();

				using var context = TestCorrelator.CreateContext();

				logger.Information("{PAYLOAD}", new ClassWithOption(Money.CreateOption(AMOUNT)));
				var logEventCollection = TestCorrelator.GetLogEventsFromContextGuid(context.Guid).ToArray();

				logEventCollection.Should().ContainSingle();
				foreach (var logEvent in logEventCollection)
				{
					using var writer = new StringWriter();
					logEvent.Properties["PAYLOAD"].Render(writer);

					writer.Flush();
					writer.ToString().Should().Contain(AMOUNT.ToString());
				}
			}
		}
	}
}