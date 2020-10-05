using System.Threading.Tasks;
using Functional.Primitives.FluentAssertions;

// ReSharper disable once CheckNamespace (make assertion methods easy to discover)
namespace Functional
{
	/// <summary>
	/// Defines additional fluent assertion gateways for types defined in Functional.Primitives namespace.
	/// </summary>
	public static class FunctionalPrimitiveAssertions
	{
		/// <summary>
		/// Returns a <see cref="ResultTypeAssertions{TSuccess,TFailure}"/> object that can be used to assert the current <see cref="Result{TSuccess, TFailure}"/>.
		/// </summary>
		/// <typeparam name="TSuccess">The success object type.</typeparam>
		/// <typeparam name="TFailure">The failure object type.</typeparam>
		/// <param name="result">The result.</param>
		/// <returns></returns>
		public static ResultTypeAssertions<TSuccess, TFailure> Should<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
		{
			return new ResultTypeAssertions<TSuccess, TFailure>(result);
		}

		/// <summary>
		/// Returns a <see cref="ResultTypeAssertions{TSuccess,TFailure}"/> object that can be used to assert the current <see cref="Result{TSuccess, TFailure}"/>.
		/// </summary>
		/// <typeparam name="TSuccess">The success object type.</typeparam>
		/// <typeparam name="TFailure">The failure object type.</typeparam>
		/// <param name="result">The result.</param>
		/// <returns></returns>
		public static async Task<ResultTypeAssertions<TSuccess, TFailure>> Should<TSuccess, TFailure>(this Task<Result<TSuccess, TFailure>> result)
		{
			return (await result).Should();
		}

		/// <summary>
		/// Returns a <see cref="OptionTypeAssertions{T}"/> object that is used to assert the current <see cref="Option{T}"/>.
		/// </summary>
		/// <typeparam name="T">The option type.</typeparam>
		/// <param name="option">The option.</param>
		/// <returns></returns>
		public static OptionTypeAssertions<T> Should<T>(this Option<T> option)
		{
			return new OptionTypeAssertions<T>(option);
		}

		/// <summary>
		/// Returns a <see cref="OptionTypeAssertions{T}"/> object that is used to assert the current <see cref="Option{T}"/>.
		/// </summary>
		/// <typeparam name="T">The option type.</typeparam>
		/// <param name="option">The option.</param>
		/// <returns></returns>
		public static async Task<OptionTypeAssertions<T>> Should<T>(this Task<Option<T>> option)
		{
			return (await option).Should();
		}
	}
}
