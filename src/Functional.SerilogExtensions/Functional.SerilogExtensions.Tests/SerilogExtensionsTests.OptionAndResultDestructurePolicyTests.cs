using System.IO;
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
		public class OptionAndResultDestructurePolicyTests
		{
			/*[Fact]
			public void WriteClassContainingResultOfOptionOfComplexType()
			{
				const int AMOUNT = 1337;

				var logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					//.Destructure.With(new OptionDestructurePolicy())
					//.Destructure.With(new ResultDestructurePolicy())
					.CreateLogger();

				using var context = TestCorrelator.CreateContext();

				logger.Information("{PAYLOAD}", new ClassWithResultOfOption(Result.Success<Option<Money>, string>(Option.Some(new Money(AMOUNT)))));
				var logEventCollection = TestCorrelator.GetLogEventsFromContextGuid(context.Guid).ToArray();

				logEventCollection.Should().ContainSingle();
				foreach (var logEvent in logEventCollection)
				{
					using var writer = new StringWriter();
					logEvent.Properties["PAYLOAD"].Render(writer);

					writer.Flush();
					writer.ToString().Should().Contain(AMOUNT.ToString());
				}
			}*/
		}
	}
}