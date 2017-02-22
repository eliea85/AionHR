using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Services.Messaging
{
    /// <summary>
    ///Generic Class used to build up a list request to be sent to a service
    /// </summary>
    public class ListRequest:RequestBase
    {
        /// <summary>
        /// the filter string
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// number of record to return
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// the index to start fetching the data store.
        /// </summary>
        public string StartAt { get; set; }

        /// <summary>
        /// parameter list shipped with the web request
        /// </summary>
        private Dictionary<string, string> parameters;

        public Dictionary<string, string> QueryStringParams;
        /// <summary>
        /// /// parameter list shipped with the web request
        /// </summary>
        public Dictionary<string, string> Parameters
        {

            get
            {
                parameters = new Dictionary<string, string>();
                parameters.Add("_filter", Filter);
                parameters.Add("_size", Size);
                parameters.Add("_startAt", StartAt);
                foreach (var item in QueryStringParams)
                {
                    parameters.Add(item.Key, item.Value);
                }
                return parameters;
            }
        }

        public ListRequest()
        {
            QueryStringParams = new Dictionary<string, string>();
        }
    }
}
