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
        [JsonProperty("censored_compile_message")]
        public string CensoredCompileMessage { get; set; }

        [JsonProperty("codechecker_hash")]
        public string CodecheckerHash { get; set; }

        [JsonProperty("compile_command")]
        public string CompileCommand { get; set; }

        [JsonProperty("compilemessage")]
        public string CompileMessage { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("memory")]
        public long[] Memory { get; set; }

        [JsonProperty("message")]
        public string[] Message { get; set; }

        [JsonProperty("stderr")]
        public bool[] Errors { get; set; }

        [JsonProperty("stdout")]
        public string[] StdOuts { get; set; }

        [JsonProperty("time")]
        public double[] Times { get; set; }
    }
}
