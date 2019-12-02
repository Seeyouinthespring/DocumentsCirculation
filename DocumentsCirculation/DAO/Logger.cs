using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsCirculation.DAO
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}