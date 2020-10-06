using FluentAssertions;
using FluentAssertions.Primitives;
using System.Threading.Tasks;

namespace Functional.Unions.FluentAssertions
{
	public static partial class UnionValueTypeAssertionsExtensions
	{
		/// <summary>
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions"/>.</param>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndConstraint<ObjectAssertions>> Be<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> source, IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> expected, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> (await source).Be(expected, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TOne"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TOne>> BeOfTypeOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> (await source).BeOfTypeOne(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TTwo"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TTwo>> BeOfTypeTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> (await source).BeOfTypeTwo(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject's value is of type <see cref="TThree"/>.
		/// </summary>
		/// <typeparam name="TUnionType">Type of the union.</typeparam>
		/// <typeparam name="TUnionDefinition">Type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="source">The source <see cref="UnionValueTypeAssertions"/>.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndUnionValueConstraint<TThree>> BeOfTypeThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(this Task<UnionValueTypeAssertions<TUnionType, TUnionDefinition, TOne, TTwo, TThree>> source, string because = "", params object[] becauseArgs)
			where TUnionType : struct
			where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition, TOne, TTwo, TThree>
			=> (await source).BeOfTypeThree(because, becauseArgs);
	}
}
