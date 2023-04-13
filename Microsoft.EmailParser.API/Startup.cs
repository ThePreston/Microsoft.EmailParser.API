using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EmailParser.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Microsoft.EmailParser.API.Startup))]
namespace Microsoft.EmailParser.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddLogging();

            builder.Services.AddScoped<IEPService, EPService>();


            //builder.Services.AddTransient(Provider => {

            //    //Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
            //    Uri accountUri = new Uri(config["BlobStorageContainer"].ToString());

            //    return new BlobServiceClient(accountUri, new DefaultAzureCredential());

            //});
            
        }
    }
}
