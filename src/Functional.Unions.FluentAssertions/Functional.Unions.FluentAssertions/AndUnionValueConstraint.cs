namespace Functional.Unions.FluentAssertions
{
	/// <summary>
	/// Encapsulates a value that assertions will be performed on.
	/// </summary>
	/// <typeparam name="T">The type to perform assertions on.</typeparam>
	public class AndUnionValueConstraint<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AndUnionValueConstraint{T}"/> class.
		/// </summary>
		/// <param name="subject">The subject.</param>
		public AndUnionValueConstraint(T subject)
		{
			AndValue = subject;
		}

		/// <summary>
		/// The value to perform assertions on.
		/// </summary>
		public T AndValue { get; }
	}
}
