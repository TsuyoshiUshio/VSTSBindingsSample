using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace VSTSBindings
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class VSTSAttribute : Attribute
    {
        public string Pat { get; set; }

        public string AccountName { get; set; }

        public string ProjectName { get; set; }

        public string BuildName { get; set; }

        public VSTSAttribute(string accountName, string projectName, string buildName)
        {
            Pat = Environment.GetEnvironmentVariable("VSTS:Pat");
            AccountName = accountName;
            ProjectName = projectName;
            BuildName = buildName;
        }
    }
}
