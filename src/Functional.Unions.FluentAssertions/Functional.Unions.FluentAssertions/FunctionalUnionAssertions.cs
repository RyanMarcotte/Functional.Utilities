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
	}
}
