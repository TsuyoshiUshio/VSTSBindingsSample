using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VSTSBindings
{
    public class VSTSCollector : IAsyncCollector<VSTSContext>
    {
        private static readonly HttpClient client;

        static VSTSCollector()
        {
            client = new HttpClient();
        }

        private VSTSAttribute attribute;
        public VSTSCollector(VSTSAttribute attribute)
        {
            this.attribute = attribute;
        }
        public async Task AddAsync(VSTSContext item, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (item.QueueBuild)
            {
                ConfigureClient();
                int definitionId = await GetDefinitionIdAsync(item);
                await QueueBuild(definitionId);
            }
        }

        private void ConfigureClient()
        {
            client.BaseAddress = new Uri($"https://{attribute.AccountName}.visualstudio.com");
            var base64Pat = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", attribute.Pat)));
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Pat);
        }

        private async Task QueueBuild(int definitionId)
        {
            
            var content = new StringContent("{\"definition\": {\"id\": " + definitionId + "}}", new UTF8Encoding(), "application/json");
            await client.PostAsync($"{attribute.ProjectName}/_apis/build/builds?api-version=4.1-preview", content);
        }

        private async Task<int> GetDefinitionIdAsync(VSTSContext item)
        {
            

            var response = await client.GetAsync($"{attribute.ProjectName}/_apis/build/definitions?api-version=4.1-preview&name={attribute.BuildName}");
  
            var result = await response.Content.ReadAsStringAsync();
            var resultOjbect = JsonConvert.DeserializeObject<Rootobject>(result);
            if (resultOjbect.count == 0) throw new ArgumentException($"Specified Build definition can not find. AccountName: {attribute.AccountName} ProjectName: {attribute.ProjectName} BuildName: {attribute.BuildName} ");
            return resultOjbect.value[0].id;
            
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }
    }
}
