using Functional.Unions.FluentAssertions;

namespace Functional
{
	/// <summary>
	/// Defines additional fluent assertion gateways for types defined in Functional.Unions namespace.
	/// </summary>
	public static class FunctionalUnionAssertions
	{
		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo> Should<TOne, TTwo>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo>, AdhocUnionDefinition<TOne, TTwo>, TOne, TTwo>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo> Should<TUnionDefinition, TOne, TTwo>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree> Should<TOne, TTwo, TThree>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree>, AdhocUnionDefinition<TOne, TTwo, TThree>, TOne, TTwo, TThree>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree> Should<TUnionDefinition, TOne, TTwo, TThree>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour> Should<TOne, TTwo, TThree, TFour>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour>, TOne, TTwo, TThree, TFour>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour> Should<TUnionDefinition, TOne, TTwo, TThree, TFour>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive> Should<TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive>, TOne, TTwo, TThree, TFour, TFive>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> Should<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix> Should<TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix>, TOne, TTwo, TThree, TFour, TFive, TSix>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> Should<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Should<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> unionValue)
			=> new UnionValueTypeAssertions<Union<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, AdhocUnionDefinition<TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
		/// </summary>
		/// <typeparam name="TUnionDefinition">The type of the union definition.</typeparam>
		/// <typeparam name="TOne"></typeparam>
		/// <typeparam name="TTwo"></typeparam>
		/// <typeparam name="TThree"></typeparam>
		/// <typeparam name="TFour"></typeparam>
		/// <typeparam name="TFive"></typeparam>
		/// <typeparam name="TSix"></typeparam>
		/// <typeparam name="TSeven"></typeparam>
		/// <param name="unionValue">The <see cref="IUnionValue"/> to perform assertions on.</param>
		/// <returns></returns>
		public static UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> Should<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(this IUnionValue<UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>> unionValue)
			where TUnionDefinition : UnionDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>
			=> new UnionValueTypeAssertions<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(unionValue);

		/// <summary>
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
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
		/// Returns a <see cref="UnionValueTypeAssertions"/> object that can be used to assert the current <see cref="IUnionValue"/>.
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
	}
}
