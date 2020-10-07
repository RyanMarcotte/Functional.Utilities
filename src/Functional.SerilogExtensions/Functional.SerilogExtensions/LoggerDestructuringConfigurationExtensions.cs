using System;
using Functional.SerilogExtensions;

// ReSharper disable once CheckNamespace (make the extensions easy to discover)
namespace Serilog.Configuration
{
	public static class LoggerDestructuringConfigurationExtensions
	{
		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source)
			=> source.With(new OptionDestructurePolicy(), new ResultDestructurePolicy());

		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source, Func<object> noValueFactory, Func<object, object> successValueFactory, Func<object, object> failureValueFactory)
			=> source.With(new OptionDestructurePolicy(noValueFactory), new ResultDestructurePolicy(successValueFactory, failureValueFactory));
	}
}