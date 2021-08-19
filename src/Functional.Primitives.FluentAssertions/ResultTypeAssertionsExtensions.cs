using FluentAssertions.Primitives;
using System;
using System.Threading.Tasks;
using Functional;

// ReSharper disable once CheckNamespace (make assertion methods easy to discover)
namespace FluentAssertions
{
	/// <summary>
	/// A collection of extensions for <see cref="ResultTypeAssertions{TSuccess, TFailure}"/>
	/// </summary>
	public static class ResultTypeAssertionsExtensions
	{
		/// <summary>
		/// Verifies that the subject is equal to an expected value.
		/// </summary>
		/// <typeparam name="TSuccess">The success value type.</typeparam>
		/// <typeparam name="TFailure">The failure value type.</typeparam>
		/// <param name="source">The source <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> task.</param>
		/// <param name="expected">The expected value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndConstraint<ObjectAssertions>> Be<TSuccess, TFailure>(this Task<ResultTypeAssertions<TSuccess, TFailure>> source, Result<TSuccess, TFailure> expected, string because = "", params object[] becauseArgs)
			=> (await source).Be(expected, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.
		/// </summary>
		/// <typeparam name="TSuccess">The success value type.</typeparam>
		/// <typeparam name="TFailure">The failure value type.</typeparam>
		/// <param name="source">The source <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> task.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndResultSuccessConstraint<TSuccess>> BeSuccessful<TSuccess, TFailure>(this Task<ResultTypeAssertions<TSuccess, TFailure>> source, string because = "", params object[] becauseArgs)
			=> (await source).BeSuccessful(because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <typeparam name="TSuccess">The success value type.</typeparam>
		/// <typeparam name="TFailure">The failure value type.</typeparam>
		/// <param name="source">The source <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> task.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		/// <returns></returns>
		public static async Task<AndResultFailureConstraint<TFailure>> BeFaulted<TSuccess, TFailure>(this Task<ResultTypeAssertions<TSuccess, TFailure>> source, string because = "", params object[] becauseArgs)
			=> (await source).BeFaulted(because, becauseArgs);

		/// <summary>
		/// Invokes the provided action on the successful value of the result.
		/// </summary>
		/// <typeparam name="TSuccess">The success value type.</typeparam>
		/// <param name="source">The <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> task with the success value to perform additional assertion actions on.</param>
		/// <param name="action">The assertion action to perform on the result's success value.</param>
		/// <returns></returns>
		public static async Task AndSuccessValue<TSuccess>(this Task<AndResultSuccessConstraint<TSuccess>> source, Action<TSuccess> action)
			=> action((await source).AndSuccessValue);

		/// <summary>
		/// Invokes the provided action on the failure value of the result.
		/// </summary>
		/// <typeparam name="TFailure">The failure value type.</typeparam>
		/// <param name="source">The <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> task with the failure value to perform additional assertion actions on.</param>
		/// <param name="action">The assertion action to perform on the result's failure value.</param>
		/// <returns></returns>
		public static async Task AndFailureValue<TFailure>(this Task<AndResultFailureConstraint<TFailure>> source, Action<TFailure> action)
			=> action((await source).AndFailureValue);
	}
}
