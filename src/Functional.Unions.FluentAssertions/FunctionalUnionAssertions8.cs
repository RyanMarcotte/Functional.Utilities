using Functional.Unions.FluentAssertions;
using System.Threading.Tasks;

namespace Functional
{
	/// <summary>
	/// Defines additional fluent assertion gateways for types defined in Functional.Unions namespace.
	/// </summary>
	public static partial class FunctionalUnionAssertions
	{
		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven,TEight}"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <typeparam name="TEight"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Should<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven,TEight}"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <typeparam name="TEight"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> Should<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven,TEight}"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <typeparam name="TEight"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static async Task<UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Should<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(await unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions{TUnionType,TUnionDefinition,TOne,TTwo,TThree,TFour,TFive,TSix,TSeven,TEight}"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <typeparam name="TEight"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static async Task<UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>> Should<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(this IUnionTask<IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(await unionValue);
	}
}
