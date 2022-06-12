using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace tt_crud
{
    public class Utility
    {


        public static string UrlPath(string fn)
        {
            string rs = "http://localhost/TT_api/api/" + fn;
            return rs;
        }



        public static string UploadString(object input, string nameApi)
        {
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(UrlPath(nameApi), inputJson);
            return json;
        }




        public static string DownloadString(string nameApi)
        {
            var webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Encoding = UTF8Encoding.UTF8;
            string path = UrlPath(nameApi);
            string json = webClient.DownloadString(path);
            return json;
        }

    }
}