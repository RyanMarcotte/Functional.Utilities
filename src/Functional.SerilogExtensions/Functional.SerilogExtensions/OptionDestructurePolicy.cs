using System;
using Serilog.Core;
using Serilog.Events;

namespace Functional.SerilogExtensions
{
	public class OptionDestructurePolicy : IDestructuringPolicy
	{
		public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
		{
			throw new NotImplementedException();
		}
	}
}
