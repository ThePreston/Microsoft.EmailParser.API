using Microsoft.EmailParser.Service.Models;

namespace Microsoft.EmailParser.Service
{
    public interface IEPService
    {
        ResponseBody ProcessBody(string body);
    }
}