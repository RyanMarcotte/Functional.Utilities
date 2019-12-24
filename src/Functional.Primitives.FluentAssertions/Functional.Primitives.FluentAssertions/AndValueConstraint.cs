using System.Diagnostics;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// Encapsulates a value that assertions will be performed on.
	/// </summary>
	/// <typeparam name="T">The type to perform assertions on.</typeparam>
	[DebuggerNonUserCode]
	public class AndValueConstraint<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AndValueConstraint{T}"/> class.
		/// </summary>
		/// <param name="subject">The subject.</param>
		public AndValueConstraint(T subject)
		{
			AndValue = subject;
		}

		/// <summary>
		/// The value to perform assertions on.
		/// </summary>
		public T AndValue { get; }
	}
}