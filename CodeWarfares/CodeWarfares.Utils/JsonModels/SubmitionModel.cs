using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.JsonModels
{
    public class SubmitionModel
    {
        [JsonProperty("memory")]
        public long Memory { get; set; }

        [JsonProperty("cmpinfo")]
        public string Message { get; set; }

        [JsonProperty("stderr")]
        public string Error { get; set; }

        [JsonProperty("output")]
        public string StdOut { get; set; }

        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("result")]
        public int Result { get; set; }
    }
}
