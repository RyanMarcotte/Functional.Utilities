using System;
using Functional;
using Functional.Primitives.SerilogExtensions;

// ReSharper disable once CheckNamespace (make the extensions easy to discover)
namespace Serilog.Configuration
{
	/// <summary>
	/// Extension methods for <see cref="LoggerDestructuringConfiguration"/> class.
	/// </summary>
	public static class LoggerDestructuringConfigurationExtensions
	{
		/// <summary>
		/// Adds <see cref="OptionDestructurePolicy"/> and <see cref="ResultDestructurePolicy"/> to the <see cref="LoggerConfiguration"/>.
		/// </summary>
		/// <param name="source">The <see cref="LoggerDestructuringConfiguration"/> instance.</param>
		/// <returns></returns>
		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source)
			=> source.FunctionalOptionAndResultTypes(new OptionDestructurePolicyConfiguration(), new ResultDestructurePolicyConfiguration());

		/// <summary>
		/// Adds <see cref="OptionDestructurePolicy"/> and <see cref="ResultDestructurePolicy"/> to the <see cref="LoggerConfiguration"/>.
		/// </summary>
		/// <param name="source">The <see cref="LoggerDestructuringConfiguration"/> instance.</param>
		/// <param name="optionConfiguration">The configuration for logging <see cref="Option{TValue}"/>.</param>
		/// <param name="resultConfiguration">The configuration for logging <see cref="Result{TSuccess,TFailure}"/>.</param>
		/// <returns></returns>
		public static LoggerConfiguration FunctionalOptionAndResultTypes(this LoggerDestructuringConfiguration source, OptionDestructurePolicyConfiguration optionConfiguration, ResultDestructurePolicyConfiguration resultConfiguration)
			=> source.With(new OptionDestructurePolicy(optionConfiguration), new ResultDestructurePolicy(resultConfiguration));
	}
}