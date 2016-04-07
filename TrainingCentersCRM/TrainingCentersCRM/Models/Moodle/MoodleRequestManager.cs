using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Xml.Serialization;

namespace TrainingCentersCRM.Models.Moodle
{
    public class MoodleRequestManager
    {
        private static MoodleRestResponse getCachedResponse(string methodName, HttpContextBase context)
        {
            if (context.Cache[methodName] != null)
                return (MoodleRestResponse)context.Cache[methodName];
            else
                return null;
        }

        public static void setCachedResponse(string methodName, MoodleRestResponse resp, HttpContextBase context)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(60);
            context.Cache.Add(methodName, resp, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), System.Web.Caching.CacheItemPriority.Normal, null);
        }

        public static MoodleRestResponse InvokeMethod(string methodName, HttpContextBase context, params KeyValuePair<string, string>[] requestParams)
        {
            var cache = getCachedResponse(methodName, context);
            if (cache != null)
                return cache;
            RestClient client = new RestClient(ConfigurationManager.AppSettings["MoodleBaseAddress"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["RestAddress"]);
            request.AddParameter("wstoken", ConfigurationManager.AppSettings["SecretKey"]);
            request.AddParameter("wsfunction", methodName);
            if (requestParams != null && requestParams.Length > 0)
            {
                object[] criteriaParams = new object[requestParams.Length];
                for (int i = 0; i < requestParams.Length; i++)
                    criteriaParams[i] = new { key = requestParams[i].Key, value = requestParams[i].Value };
                request.AddParameter("criteria", criteriaParams, ParameterType.RequestBody);
            }
            RestResponse<MoodleRestResponse> resp = (RestResponse<MoodleRestResponse>)client.Execute<MoodleRestResponse>(request);
            XmlSerializer ser = new XmlSerializer(typeof(MoodleRestResponse));
            MoodleRestResponse res = (MoodleRestResponse)ser.Deserialize(new StringReader(resp.Content));
            setCachedResponse(methodName, res, context);
            return res;
        }
    }
}