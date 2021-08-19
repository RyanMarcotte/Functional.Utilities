using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
	/// <summary>
	/// Encapsulates a value that assertions will be performed on.
	/// </summary>
	/// <typeparam name="T">The type to perform assertions on.</typeparam>
	[DebuggerNonUserCode]
	public class AndResultSuccessConstraint<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AndResultSuccessConstraint{T}"/> class.
		/// </summary>
		/// <param name="subject">The subject.</param>
		public AndResultSuccessConstraint(T subject)
		{
			AndSuccessValue = subject;
		}

		/// <summary>
		/// The value to perform assertions on.
		/// </summary>
		public T AndSuccessValue { get; }
	}
}