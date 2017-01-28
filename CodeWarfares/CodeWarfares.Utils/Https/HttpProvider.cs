using System;
using System.Collections.Generic;
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
        public string HttpPostJson(string url, string parameters)
        {
            WebRequest req = WebRequest.Create(url);

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. 
            //Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr =
                  new System.IO.StreamReader(resp.GetResponseStream());

            return sr.ReadToEnd().Trim();
        }
    }
}
