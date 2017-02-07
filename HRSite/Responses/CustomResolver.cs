using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.Responses
{
    public class CustomResolver:DefaultContractResolver
    {
        private Dictionary<string, string> customRules;
        public CustomResolver()
        {

            customRules = new Dictionary<string, string>();
        }

        public void AddRule(string jsonAttribute,string propertyName)
        {
            customRules.Add(propertyName, jsonAttribute);
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            if (customRules.ContainsKey(propertyName))
                return customRules[propertyName];
            else return base.ResolvePropertyName(propertyName); ;
        }

    }
}