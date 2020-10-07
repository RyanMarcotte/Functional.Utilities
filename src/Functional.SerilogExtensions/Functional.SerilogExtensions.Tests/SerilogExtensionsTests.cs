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

		private class ClassWithResult
		{
			public ClassWithResult(Result<Money, string> value)
			{
				Value = value;
			}

			public Result<Money, string> Value { get; }
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
