
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using VSTSBindings;
using System.Threading.Tasks;
using System.Net.Http;

namespace VSTSBindingsSample
{
    public static class VSTSFunction
    {
        [FunctionName("VSTSFunction")]
        public async static Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [VSTS("talkdevops", "AzureFunctionsSpike", "Node.CI") ] IAsyncCollector<bool> collector,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            await collector.AddAsync(true);
            log.Info("VSTS Queues Node.CI definition");
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent("VSTS Node.CI queued.") };
           }
    }
}
