using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Functional.SerilogExtensions.Tests._Infrastructure;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;
using Xunit.Sdk;

namespace Functional.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		// https://xunit.net/docs/shared-context#constructor
		public class OptionDestructurePolicyTests : IDisposable
		{
			private const int VALUE = 1337;

			private readonly ILogger _logger;
			private readonly ITestCorrelatorContext _context;

			public OptionDestructurePolicyTests()
			{
				_logger = new LoggerConfiguration()
					.WriteTo.Sink(new TestCorrelatorSink())
					//.Destructure.With(new OptionDestructurePolicy())
					.CreateLogger();

				_context = TestCorrelator.CreateContext();
			}

			[Theory]
			[OptionSomeOfPrimitiveType]
			[OptionSomeOfComplexType]
			[ClassContainingOptionSomeOfPrimitiveType]
			[ClassContainingOptionSomeOfComplexType]
			public void WriteOptionSome(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";
				
				_logger.Information($"{{{PROPERTY_KEY}}}", propertyValue);
				
				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().Contain(VALUE.ToString()));
			}

			[Theory]
			[OptionNoneOfPrimitiveType]
			[OptionNoneOfComplexType]
			[ClassContainingOptionNoneOfPrimitiveType]
			[ClassContainingOptionNoneOfComplexType]
			public void WriteOptionNone(object propertyValue)
			{
				const string PROPERTY_KEY = "PAYLOAD";

				_logger.Information($"{{{PROPERTY_KEY}}}", propertyValue);

				TestCorrelator.GetLogEventsFromContextGuid(_context.Guid).ToArray()
					.Should()
					.ContainSingleWithProperty($"{PROPERTY_KEY}", x => x.Should().Contain("None"));
			}

			public void Dispose()
			{
				_context.Dispose();
			}

			#region Arrangements

			private class OptionSomeOfPrimitiveType : SingleParameterArrangement
			{
				public OptionSomeOfPrimitiveType()
					: base(Option.Some(VALUE))
				{
				}
			}

			private class OptionNoneOfPrimitiveType : SingleParameterArrangement
			{
				public OptionNoneOfPrimitiveType()
					: base(Option.None<int>())
				{
				}
			}

			private class OptionSomeOfComplexType : SingleParameterArrangement
			{
				public OptionSomeOfComplexType()
					: base(Money.CreateOption(VALUE))
				{
				}
			}

			private class OptionNoneOfComplexType : SingleParameterArrangement
			{
				public OptionNoneOfComplexType()
					: base(Money.CreateOption(null))
				{
				}
			}

			private class ClassContainingOptionSomeOfPrimitiveType : SingleParameterArrangement
			{
				public ClassContainingOptionSomeOfPrimitiveType()
					: base(new ClassWithSimpleOption(Option.Some(VALUE)))
				{
				}
			}

			private class ClassContainingOptionNoneOfPrimitiveType : SingleParameterArrangement
			{
				public ClassContainingOptionNoneOfPrimitiveType()
					: base(new ClassWithSimpleOption(Option.None<int>()))
				{
				}
			}

			private class ClassContainingOptionSomeOfComplexType : SingleParameterArrangement
			{
				public ClassContainingOptionSomeOfComplexType()
					: base(new ClassWithComplexOption(Money.CreateOption(VALUE)))
				{
				}
			}

			private class ClassContainingOptionNoneOfComplexType : SingleParameterArrangement
			{
				public ClassContainingOptionNoneOfComplexType()
					: base(new ClassWithComplexOption(Money.CreateOption(null)))
				{
				}
			}

			#endregion
		}
	}
}