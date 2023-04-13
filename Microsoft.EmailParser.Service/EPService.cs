using Microsoft.EmailParser.Service.Models;
using Microsoft.Extensions.Logging;


namespace Microsoft.EmailParser.Service
{
    public class EPService : IEPService
    {

        private readonly ILogger<EPService> _logger;

        public EPService(ILogger<EPService> logger)
        {
            _logger = logger;

        }

        public ResponseBody ProcessBody(string body)
        {
            _logger.LogInformation("Entered ProcessBody");

            var resp = new ResponseBody();

            //Implementation to parse html

            resp.Cc = "";
            resp.Body = body;

            return resp;
        }
    }
}
