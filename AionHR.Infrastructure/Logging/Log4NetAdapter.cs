﻿using AionHR.Infrastructure.Configuration;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Infrastructure.Logging
{
    /// <summary>
    /// Log4netAdapter based on log4net package
    /// </summary>
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager
             .GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }

}
