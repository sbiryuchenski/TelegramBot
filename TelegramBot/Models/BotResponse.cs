using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Models
{
    public class BotResponse
    {
        public BotResponse() { }
        public BotResponse(string message, IReplyMarkup buttons)
        {
            Message = message;
            Buttons = buttons;
        }

        public string Message { get; set; }
        public IReplyMarkup Buttons { get; set; }
    }
}
