using System;
using Functional.SerilogExtensions;

// ReSharper disable once CheckNamespace (make the extensions easy to discover)
namespace Serilog.Configuration
{
	public static class LoggerDestructuringConfigurationExtensions
	{
		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source)
			=> source.FunctionalOptionAndResultTypes(new OptionDestructurePolicyConfiguration(), new ResultDestructurePolicyConfiguration());

		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source, OptionDestructurePolicyConfiguration optionConfiguration, ResultDestructurePolicyConfiguration resultConfiguration)
			=> source.With(new OptionDestructurePolicy(optionConfiguration), new ResultDestructurePolicy(resultConfiguration));
	}
}