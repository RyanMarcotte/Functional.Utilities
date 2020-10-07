using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Serilog.Events;

namespace Functional.Primitives.SerilogExtensions.Tests._Infrastructure
{
	internal class LogEventCollectionAssertions
	{
		private readonly LogEvent[] _subject;

		public LogEventCollectionAssertions(LogEvent[] subject)
		{
			_subject = subject ?? throw new ArgumentNullException(nameof(subject));
		}

		public void ContainsSingleWithProperty(string key)
		{
			_subject.AsEnumerable().Should().ContainSingle();

			// ReSharper disable once PossibleNullReferenceException (constructor disallows null)
			foreach (var logEvent in _subject)
				logEvent.Properties.TryGetValue(key, out _).Should().BeTrue($"expected property with key '{key}'");
		}

		public void ContainSingleWithProperty(string key, Action<string> action)
		{
			_subject.AsEnumerable().Should().ContainSingle();

			// ReSharper disable once PossibleNullReferenceException (constructor disallows null)
			foreach (var logEvent in _subject)
			{
				logEvent.Properties.TryGetValue(key, out var propertyValue).Should().BeTrue($"expected property with key '{key}'");

				using (var writer = new StringWriter())
				{
					// ReSharper disable once PossibleNullReferenceException
					propertyValue.Render(writer);
					writer.Flush();
					action.Invoke(writer.ToString());
				}
			}
		}
	}
}