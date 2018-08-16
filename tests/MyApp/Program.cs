using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZenLogger.Provider;

namespace MyApp {
    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            services.AddLogging(config => {
                config.ClearProviders();
                config.AddZen();
            });
            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();
            var myService = provider.GetService(typeof(MyService)) as MyService;
            myService.FunctionA();
        }
    }

    class MyService {
        private readonly ILogger<MyService> logger;

        public MyService(ILogger<MyService> logger) {
            this.logger = logger;
        }

        public void FunctionA() {
            logger.LogInformation("Hello, world");
            logger.LogInformation("Hello, world");
            logger.LogCritical("Crital ...");
            logger.LogError("Hello, world");
        }
    }
}
