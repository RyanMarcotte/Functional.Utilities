using System.Collections.Generic;
using Serilog.Events;

namespace Functional.SerilogExtensions.Tests._Infrastructure
{
	internal static class LogEventCollectionExtensions
	{
		public static LogEventCollectionAssertions Should(this LogEvent[] subject)
		{
			return new LogEventCollectionAssertions(subject);
		}
	}
}