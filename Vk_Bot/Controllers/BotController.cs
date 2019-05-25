using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vk_Bot.Controllers
{
    [Serializable]
    public class BotController
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("group_id")]
        public string Group_Id { get; set; }
    }
}
