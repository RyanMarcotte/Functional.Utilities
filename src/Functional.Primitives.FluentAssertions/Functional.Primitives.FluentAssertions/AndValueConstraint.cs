using System.Diagnostics;

namespace Functional.Primitives.FluentAssertions
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
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
		/// 
		/// </summary>
		public T AndValue { get; }
	}
}