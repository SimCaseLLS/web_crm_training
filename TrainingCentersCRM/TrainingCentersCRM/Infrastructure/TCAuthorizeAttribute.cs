using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TrainingCentersCRM.Infrastructure
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true,
    AllowMultiple = true)]
    public class TCAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException("httpContext");
            if (Roles == null) throw new ArgumentNullException("Roles required in parametrs");
            if (httpContext.User.Identity.IsAuthenticated == false) return false;
            try
            {
                var current_tc_name = TCHelper.GetCurrentTCName();
                var roles = Roles.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach( var role in roles )
                {
                    var tcRole = RolesHelper.RoleForTc(role, current_tc_name);
                    
                    if (httpContext.User.IsInRole(tcRole) || httpContext.User.IsInRole(role)) return true;
                }
                return false;
            }
            catch (Exception)
            {
                // TODO Нужны логи сюда!
                return false;
            }
        }


    }
}
