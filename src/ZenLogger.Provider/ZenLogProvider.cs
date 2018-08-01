using Microsoft.Extensions.Logging;

namespace ZenLogger.Provider {

    public class ZenLogProvider : ILoggerProvider {

        public ILogger CreateLogger(string categoryName) {
            return new ZenLogger(this, categoryName);
        }

        public void Dispose() {

        }
    }
}
