using System;

namespace Functional.SerilogExtensions
{
	public class ResultDestructurePolicyConfiguration
	{
		public ResultDestructurePolicyConfiguration()
			: this(success => new { IsSuccessful = true, Data = success }, failure => new { IsSuccessful = false, Data = failure })
		{

		}

		public ResultDestructurePolicyConfiguration(Func<object, object> successValueFactory, Func<object, object> failureValueFactory)
		{
			SuccessValueFactory = successValueFactory ?? throw new ArgumentNullException(nameof(successValueFactory));
			FailureValueFactory = failureValueFactory ?? throw new ArgumentNullException(nameof(failureValueFactory));
		}

		public Func<object, object> SuccessValueFactory { get; }
		public Func<object, object> FailureValueFactory { get; }
	}
}