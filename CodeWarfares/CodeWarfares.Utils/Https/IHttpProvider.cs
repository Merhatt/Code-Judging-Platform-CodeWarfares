namespace CodeWarfares.Utils.Https
{
    public interface IHttpProvider
    {
        string HttpPostJson(string url, string parameters);
    }
}