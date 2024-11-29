using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MaciekTestAzureFunction
{
    public class MacTestFunc1
    {
        private readonly ILogger _logger;

        public MacTestFunc1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MacTestFunc1>();
        }

        [Function("MacTestFunc")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Mac Function!");

            return response;
        }
    }
}
