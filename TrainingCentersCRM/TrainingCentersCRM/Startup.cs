using Microsoft.Owin;
using Owin;
using log4net;
using log4net.Config;
using System;

[assembly: OwinStartupAttribute(typeof(TrainingCentersCRM.Startup))]
namespace TrainingCentersCRM
{
    public partial class Startup
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Startup));
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();
            ConfigureAuth(app);
        }
    }
    public static class Logger
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        public static void Error(string error, Exception ex)
        {
            log.Error(error, ex);
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }
    }
}
