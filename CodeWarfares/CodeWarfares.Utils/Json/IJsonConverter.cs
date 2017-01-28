namespace CodeWarfares.Utils.Json
{
    public interface IJsonConverter
    {
        TModel JsonToModel<TModel>(string json) where TModel : class;
        string ModelToJson<TModel>(TModel model) where TModel : class;
    }
}