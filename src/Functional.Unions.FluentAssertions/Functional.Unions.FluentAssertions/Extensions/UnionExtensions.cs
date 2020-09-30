using FluentAssertions.Execution;
using System;
using System.Text;

namespace Functional.Unions.FluentAssertions.Extensions
{
	internal static class UnionExtensions
	{
		public static FailReason GetFailReasonForBe<TUnionDefinition>(object subject, object expected)
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Expected to be equal{{reason}}, but the two IUnionValue<{typeof(TUnionDefinition)}> are not equal.");
			builder.AppendLine("Subject: " + subject);
			builder.AppendLine("Expected: " + expected);

			return new FailReason(builder.ToString());
		}

		public static FailReason GetFailReasonForBeOfType<TExpected>(Type actualType, object subject)
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Expected union value to be of type {typeof(TExpected)}{{reason}}, but value was of type {actualType} instead.");
			builder.AppendLine("Subject: " + subject);
			builder.AppendLine("Subject Type: " + actualType);
			builder.AppendLine("Expected Type: " + typeof(TExpected));

			return new FailReason(builder.ToString());
		}

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo));
	}
}
