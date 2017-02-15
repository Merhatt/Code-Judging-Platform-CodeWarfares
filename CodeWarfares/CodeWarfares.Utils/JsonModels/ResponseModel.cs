using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.JsonModels
{
    public class ResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
