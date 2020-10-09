using System;

namespace Functional.Primitives.SerilogExtensions
{
	/// <summary>
	/// Encapsulates configuration options for writing <see cref="Result{TSuccess,TFailure}"/> log event properties.
	/// </summary>
	public class ResultDestructurePolicyConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ResultDestructurePolicyConfiguration"/> class.
		/// </summary>
		public ResultDestructurePolicyConfiguration()
			: this(success => new { IsSuccessful = true, Data = success }, failure => new { IsSuccessful = false, Data = failure })
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultDestructurePolicyConfiguration"/> class.
		/// </summary>
		/// <param name="successValueFactory">The function to invoke when processing a <see cref="Result{TSuccess,TFailure}"/> that is successful.</param>
		/// <param name="failureValueFactory">The function to invoke when processing a <see cref="Result{TSuccess,TFailure}"/> that is faulted.</param>
		public ResultDestructurePolicyConfiguration(Func<object, object> successValueFactory, Func<object, object> failureValueFactory)
		{
			SuccessValueFactory = successValueFactory ?? throw new ArgumentNullException(nameof(successValueFactory));
			FailureValueFactory = failureValueFactory ?? throw new ArgumentNullException(nameof(failureValueFactory));
		}

		/// <summary>
		/// The function to invoke when processing a <see cref="Result{TSuccess,TFailure}"/> that is successful.
		/// </summary>
		public Func<object, object> SuccessValueFactory { get; }

		/// <summary>
		/// The function to invoke when processing a <see cref="Result{TSuccess,TFailure}"/> that is faulted.
		/// </summary>
		public Func<object, object> FailureValueFactory { get; }
	}
}