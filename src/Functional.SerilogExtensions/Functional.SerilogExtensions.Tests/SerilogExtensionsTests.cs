using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Functional.SerilogExtensions.Tests
{
	public partial class SerilogExtensionsTests
	{
		private class SingleParameterArrangement : DataAttribute
		{
			private readonly InlineDataAttribute _inlineData;

			public SingleParameterArrangement(object value)
			{
				_inlineData = new InlineDataAttribute(value);
			}

			public override IEnumerable<object[]> GetData(MethodInfo testMethod) => _inlineData.GetData(testMethod);
		}

		[DebuggerDisplay("${" + nameof(AmountInDollars) + "}")]
		private class Money
		{
			public static Option<Money> CreateOption(decimal? amountInDollars)
				=> Option.FromNullable(amountInDollars).Map(value => new Money(value));

			public Money(decimal amountInDollars)
			{
				AmountInDollars = amountInDollars;
			}

			public decimal AmountInDollars { get; }
		}

		public class Error
		{
			public Error(string message)
			{
				Message = message ?? throw new ArgumentNullException(nameof(message));
			}

			public string Message { get; }
		}

		private class ClassWithSimpleOption
		{
			public ClassWithSimpleOption(Option<int> value)
			{
				Value = value;
			}

			public Option<int> Value { get; }
		}

		private class ClassWithComplexOption
		{
			public ClassWithComplexOption(Option<Money> value)
			{
				Value = value;
			}

			public Option<Money> Value { get; }
		}

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

		private class ClassWithResultOfOption
		{
			public ClassWithResultOfOption(Result<Option<Money>, string> value)
			{
				Value = value;
			}

			public Result<Option<Money>, string> Value { get; }
		}
	}
}
