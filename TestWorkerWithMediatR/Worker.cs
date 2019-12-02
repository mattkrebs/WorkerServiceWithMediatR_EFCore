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

        /// <summary>
        /// WORKER service with out Creating scope within the background service
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.0&tabs=visual-studio#consuming-a-scoped-service-in-a-background-task
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>

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
              

                _logger.LogInformation("Get me the Query {resopnse}", await _mediator.Send(new SampleQuery()));
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
