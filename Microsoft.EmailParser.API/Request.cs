using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.EmailParser.API.Models;
using Microsoft.EmailParser.Service;
using Microsoft.EmailParser.Service.Common;
using Microsoft.EmailParser.Service.Models;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Microsoft.EmailParser.API
{
    public class Request
    {
        private readonly ILogger<Request> _logger;

        private readonly IEPService _svc;

        public Request(ILogger<Request> log, IEPService ePService)
        {
            _logger = log;
            _svc = ePService;
        }

        [FunctionName("ProcessEmail")]
        [OpenApiOperation(operationId: "ProcessEmail")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "text/plain", bodyType: typeof(string), Description = "Parameters", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "applcation/json", bodyType: typeof(ResponseBody), Description = "The OK response")]
        public async Task<HttpResponseMessage> ProcessEmail(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                return HttpUtilities.RESTResponse(_svc.ProcessBody(requestBody));

            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return HttpUtilities.RESTResponse(ex);

            }
        }
    }
}