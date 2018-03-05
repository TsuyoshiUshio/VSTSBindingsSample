using Microsoft.Azure.WebJobs.Host.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace VSTSBindings
{
    public class VSTSConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddConverter<bool, VSTSContext>(input => new VSTSContext { QueueBuild = input });
            context.AddBindingRule<VSTSAttribute>().BindToCollector<VSTSContext>(attr => new VSTSCollector(attr));
        }
    }
}
