using FluentAssertions;
using FluentAssertions.Primitives;
using Functional.Unions.FluentAssertions;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace (ease of discoverability)
namespace Functional
{
	/// <summary>
	/// Extension methods for the <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/> class.
	/// </summary>
	public static class UnionValueTypeAssertionsExtensions7
	{
		/// <summary>
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndConstraint<ObjectAssertions>> Be<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> expected, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).Be(expected, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TOne"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TOne>> BeOfTypeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeOne(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TTwo"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TTwo>> BeOfTypeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeTwo(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TThree"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TThree>> BeOfTypeThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeThree(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TFour"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TFour>> BeOfTypeFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeFour(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TFive"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TFive>> BeOfTypeFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeFive(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TSix"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TSix>> BeOfTypeSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeSix(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <typeparamref name="TSeven"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven}"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TSeven>> BeOfTypeSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> (await source).BeOfTypeSeven(because, becauseArgs);
	}
}
