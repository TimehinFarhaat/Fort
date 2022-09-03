using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Fort.Interfaces.Service;

namespace Fort.Implementation.Service
{
    public class SmsBackgroundTasks : BackgroundService
    {
       // private readonly IResponseService _responseService;
        public SmsBackgroundTasks()
        {
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("ASSSSSSSDFGHJMMMMMMMM");
            return Task.CompletedTask;
        }
    }
}

