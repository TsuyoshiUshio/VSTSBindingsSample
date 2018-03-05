using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace VSTSBindings
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class VSTSAttribute : Attribute
    {
        public string Pat { get; set; }

        public string AccountName { get; set; }

        public string BuildName { get; set; }

        public VSTSAttribute(string accountName, string buildName)
        {
            Pat = Environment.GetEnvironmentVariable("VSTS:Pat");
            AccountName = accountName;
            BuildName = buildName;
        }
    }
}
