using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FluentAssertions;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Functional.SerilogExtensions.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
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

		private class ClassWithOption
		{
			public ClassWithOption(Option<Money> value)
			{
				Value = value;
			}

			public Option<Money> Value { get; }
		}

		private class ClassWithResult
		{
			public ClassWithResult(Result<Money, string> value)
			{
				Value = value;
			}

			public Result<Money, string> Value { get; }
		}

        [DebuggerDisplay("${" + nameof(AmountInDollars) + "}")]
        private class Money : IEquatable<Money>
        {
            public static Option<Money> CreateOption(decimal? amountInDollars)
                => Option.FromNullable(amountInDollars).Map(value => new Money(value));

            public Money(decimal amountInDollars)
            {
                AmountInDollars = amountInDollars;
            }

            public decimal AmountInDollars { get; }

            public bool Equals(Money other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;

                return AmountInDollars == other.AmountInDollars;
            }

            public override bool Equals(object obj)
            {
				if (obj is null) return false;
				if (ReferenceEquals(this, obj)) return true;

                return obj.GetType() == GetType() && Equals((Money)obj);
            }

            public override int GetHashCode() => AmountInDollars.GetHashCode();
            public static bool operator ==(Money left, Money right) => Equals(left, right);
            public static bool operator !=(Money left, Money right) => !Equals(left, right);
        }
    }
}
