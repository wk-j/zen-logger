using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ZenLogger.Provider {
    public class ZenLogger : ILogger {

        private readonly ZenLogProvider provider;
        private readonly string category;

        public ZenLogger(ZenLogProvider provider, string categoryName) {
            this.provider = provider;
            this.category = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state) {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (!IsEnabled(logLevel)) return;
            var builder = new StringBuilder();
            builder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"));
            builder.Append(" [");
            builder.Append(logLevel.ToString());
            builder.Append("] ");
            builder.Append(category);
            builder.Append(": ");
            builder.AppendLine(formatter(state, exception));
            Console.WriteLine(builder.ToString());
        }
    }

    public static class ZenLoggerExtensions {
        public static ILoggingBuilder AddWk(this ILoggingBuilder builder) {
            builder.Services.AddSingleton<ILoggerProvider, ZenLogProvider>();
            return builder;
        }
    }


    public class ZenLogOptions { }
    public class ZenLogProvider : ILoggerProvider {

        public ILogger CreateLogger(string categoryName) {
            return new ZenLogger(this, categoryName);
        }

        public void Dispose() {

        }
    }
}
