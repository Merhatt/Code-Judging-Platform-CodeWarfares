using System.Collections.Generic;

namespace CodeWarfares.Utils.Https
{
    public interface IHttpProvider
    {
        string HttpPostJson(string url, string parameters);

        string HttpPostJson(string url, string parameters, IDictionary<string, string> body);

        string HttpGetJson(string url);
    }
}