using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRStuff;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWorkerWithMediatR
{
    public class ScopedWorker : BackgroundService
    {
        private readonly ILogger<ScopedWorker> _logger;

        public IServiceProvider Services { get; }

        public ScopedWorker(ILogger<ScopedWorker> logger, IServiceProvider service)
        {
            _logger = logger;
            Services = service;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (var scope = Services.CreateScope())
                {
                    var mediator =
                        scope.ServiceProvider
                            .GetRequiredService<IMediator>();

                    
                    _logger.LogInformation("Get me the Response: {resopnse}", await mediator.Send(new SampleQuery()));
                }

               
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
