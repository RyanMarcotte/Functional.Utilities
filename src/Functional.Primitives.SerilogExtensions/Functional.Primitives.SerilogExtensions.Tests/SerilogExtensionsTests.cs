using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Functional.Primitives.SerilogExtensions.Tests
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
	}
}
