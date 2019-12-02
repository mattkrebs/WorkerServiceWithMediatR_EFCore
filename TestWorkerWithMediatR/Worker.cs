using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRStuff;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWorkerWithMediatR
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (var scope = Services.CreateScope())
                {
                    var scopedProcessingService =
                        scope.ServiceProvider
                            .GetRequiredService<IScopedProcessingService>();

                    await scopedProcessingService.DoWork(stoppingToken);
                }

                _logger.LogInformation("Get me the Query {resopnse}", await _mediator.Send(new SampleQuery()));
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
