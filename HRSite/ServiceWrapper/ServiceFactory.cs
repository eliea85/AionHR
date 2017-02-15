using HRSite.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSite.ServiceWrapper
{
    public static class ServiceFactory
    {


        private const string servicesUrl = "http://webservices.aionhr.net/";

        private const string EPUrl = "EP.asmx/";
        private const string CSUrl = "CS.asmx/";
        private const string LMURL = "LM.asmx/";
        private const string SYUrl = "SY.asmx/";
        private const string TAUrl = "TA.asmx/";
         static ServiceFactory()
        {
            EP.serviceUrl = servicesUrl + EPUrl;
            CS.serviceUrl = servicesUrl + CSUrl;
            LM.serviceUrl = servicesUrl + LMURL;
            
            TA.serviceUrl = servicesUrl + TAUrl;
            SY.serviceUrl = servicesUrl + SYUrl;
        }

        public static void Init()
        { }


    }
}