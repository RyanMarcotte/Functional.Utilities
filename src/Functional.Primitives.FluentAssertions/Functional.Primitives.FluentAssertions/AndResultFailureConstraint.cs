using System.Diagnostics;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Encapsulates a value that assertions will be performed on.
	/// </summary>
	/// <typeparam name="T">The type to perform assertions on.</typeparam>
	[DebuggerNonUserCode]
	public class AndResultFailureConstraint<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AndResultFailureConstraint{T}"/> class.
		/// </summary>
		/// <param name="subject">The subject.</param>
		public AndResultFailureConstraint(T subject)
		{
			AndFailureValue = subject;
		}

		/// <summary>
		/// The value to perform assertions on.
		/// </summary>
		public T AndFailureValue { get; }
	}
}