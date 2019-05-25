using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet.Utils;

namespace Vk_Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallBackController: ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IVkApi vkApi;
        public CallBackController(IConfiguration config,IVkApi vkontApi)
        {
            configuration = config;
            vkApi = vkontApi;
        }
        [HttpPost]
        public IActionResult Callback([FromBody] BotController updates)
        {
            switch (updates.Type)
            {
                case "confirmation":
                    return Ok(configuration["Config:Confirmation"]);
                case "message_new":
                    {
                        var msg = Message.FromJson(new VkResponse(updates.Object));

                        vkApi.Messages.Send(new MessagesSendParams
                        {
                            RandomId = new DateTime().Millisecond,
                            PeerId = msg.PeerId.Value,
                            Message = msg.Text
                        });
                        break;
                    }
                
            }
            return Ok("ok");
        }
    }
}
