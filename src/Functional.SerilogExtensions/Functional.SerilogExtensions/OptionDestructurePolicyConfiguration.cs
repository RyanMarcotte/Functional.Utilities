using System;

namespace Functional.SerilogExtensions
{
	public class OptionDestructurePolicyConfiguration
	{
		public OptionDestructurePolicyConfiguration()
			: this(value => value, () => null)
		{

		}

		public OptionDestructurePolicyConfiguration(Func<object, object> valueFactory, Func<object> noValueFactory)
		{
			ValueFactory = valueFactory;
			NoValueFactory = noValueFactory ?? throw new ArgumentNullException(nameof(noValueFactory));
		}

		public Func<object, object> ValueFactory { get; }
		public Func<object> NoValueFactory { get; }
	}
}