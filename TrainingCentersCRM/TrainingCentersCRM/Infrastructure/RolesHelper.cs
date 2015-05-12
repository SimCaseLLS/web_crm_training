using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingCentersCRM.Controllers;
using TrainingCentersCRM.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TrainingCentersCRM.Infrastructure
{
    public static class RolesHelper
    {
        public static string RoleForTc(string role, string tc)
        {
            var tcRole = tc.Equals("empty") ? role : role + "_" + tc;//выглядит как admin_ulstu, или manager_ulstu
            return tcRole;
        }

        /// <summary>
        /// Подстраивается под тренинг центр, при указании role "admin" в учебном центре usltu проверит на роль "admin_ulstu"
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool IsUserHasPermissionForTc(string role)
        {
            var tc = TCHelper.GetCurrentTCName();
            return IsUserHasPermissionForTc(role, tc);
        }

        public static bool IsUserHasPermissionForTc(string role, string tc)
        {
            var tcRole = RoleForTc(role, tc);
            // если роль admin_ulstu, то просто admin тоже будет видеть.
            return IsUserHasPermission(tcRole) || IsUserHasPermission(role);
        }

        /// <summary>
        /// Не подстраивается под тренинг центр, проверяет прямо указанную роль
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static bool IsUserHasPermission(string role)      
        {
            // FIXME Это медленнее, чем использовать HttpContext.Current.User.IsInRole(role), потому что предыдущее походу кеширует!
            // вероятно кеш обновляется в момент залогинивания пользователя. Возможно этот вариант не так плох(у нас не так много ролей, 
            // которые надо переназначать не так уж часто)
            var account = new AccountController();
            var res = account.UserManager.IsInRole(HttpContext.Current.User.Identity.GetUserId(), role);
            return res;
            //return HttpContext.Current.User.IsInRole(role);
        }
    }
}