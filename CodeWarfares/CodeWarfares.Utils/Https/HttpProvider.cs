using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.Https
{
    public class HttpProvider : IHttpProvider
    {
        public string HttpGetJson(string url)
        {
            string json = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }

        public string HttpPostJson(string url, string parameters)
        {
            WebRequest req = WebRequest.Create(url);

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            StreamReader sr = new StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }

        public string HttpPostJson(string url, string parameters, IDictionary<string, string> body)
        {
            using (WebClient client = new WebClient())
            {
                var data = new NameValueCollection();

                foreach (var item in body)
                {
                    data.Add(item.Key, item.Value);
                }

                byte[] response =
                client.UploadValues(url + "?" + parameters, data);

                string result = Encoding.UTF8.GetString(response);

                return result;
            }
        }
    }
}
