using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.Json
{
    public class JsonConverter : IJsonConverter
    {
        public TModel JsonToModel<TModel>(string json) where TModel : class
        {
            return JsonConvert.DeserializeObject<TModel>(json);
        }

        public string ModelToJson<TModel>(TModel model) where TModel : class
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
