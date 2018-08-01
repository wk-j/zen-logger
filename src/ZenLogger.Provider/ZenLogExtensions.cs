using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ZenLogger.Provider {
    public static class ZenLogExtensions {
        public static ILoggingBuilder AddZen(this ILoggingBuilder builder) {
            builder.Services.AddSingleton<ILoggerProvider, ZenLogProvider>();
            return builder;
        }
    }
}
