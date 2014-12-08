using Microsoft.Owin;
using Owin;
using log4net;
using log4net.Config;

[assembly: OwinStartupAttribute(typeof(TrainingCentersCRM.Startup))]
namespace TrainingCentersCRM
{
    public partial class Startup
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Startup));
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.DOMConfigurator.Configure();
            ConfigureAuth(app);
        }
    }
    public static class MyError
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(MyError));

        public static void Error(string error)
        {
            log.Error(error);


        }
    }
}
