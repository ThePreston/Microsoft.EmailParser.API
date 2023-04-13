namespace Microsoft.EmailParser.Service.Models
{
    public class ResponseBody
    {
        
        public string To { get; set; } = "";

        public string Cc { get; set; } = "";
        
        public string Subject { get; set; } = "";

        public string Body { get; set; } = "";

        public string BlobPathTaxonomy { get; set; } = "";

    }
}