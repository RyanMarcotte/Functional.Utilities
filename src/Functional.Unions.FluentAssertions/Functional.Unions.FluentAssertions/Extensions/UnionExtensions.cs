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

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree));

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree), four => typeof(TFour));

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree), four => typeof(TFour), five => typeof(TFive));

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree), four => typeof(TFour), five => typeof(TFive), six => typeof(TSix));

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree), four => typeof(TFour), five => typeof(TFive), six => typeof(TSix), seven => typeof(TSeven));

		public static Type GetValueType<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> unionValue)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> unionValue.Match(one => typeof(TOne), two => typeof(TTwo), three => typeof(TThree), four => typeof(TFour), five => typeof(TFive), six => typeof(TSix), seven => typeof(TSeven), eight => typeof(TEight));
	}
}
