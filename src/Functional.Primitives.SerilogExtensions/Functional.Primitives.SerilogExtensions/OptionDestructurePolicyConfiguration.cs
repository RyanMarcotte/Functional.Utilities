using System;

namespace Functional.Primitives.SerilogExtensions
{
	/// <summary>
	/// Encapsulates configuration options for writing <see cref="Option{TValue}"/> log event properties.
	/// </summary>
	public class OptionDestructurePolicyConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OptionDestructurePolicyConfiguration"/> class.
		/// </summary>
		public OptionDestructurePolicyConfiguration()
			: this(value => value, () => null)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="OptionDestructurePolicyConfiguration"/> class.
		/// </summary>
		/// <param name="valueFactory">The function to invoke when processing an <see cref="Option{TValue}"/> that holds a value.</param>
		/// <param name="noValueFactory">The function to invoke when processing an <see cref="Option{Value}"/> that does not hold a value.</param>
		public OptionDestructurePolicyConfiguration(Func<object, object> valueFactory, Func<object> noValueFactory)
		{
			ValueFactory = valueFactory;
			NoValueFactory = noValueFactory ?? throw new ArgumentNullException(nameof(noValueFactory));
		}

		/// <summary>
		/// The function to invoke when processing an <see cref="Option{TValue}"/> that holds a value.
		/// </summary>
		public Func<object, object> ValueFactory { get; }

		/// <summary>
		/// The function to invoke when processing an <see cref="Option{Value}"/> that does not hold a value.
		/// </summary>
		public Func<object> NoValueFactory { get; }
	}
}