using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    public class BaseDialog
    {
        public static async void SendMessageToUser(ITelegramBotClient botClient, long id, string message/*, IReplyMarkup buttons*/)
        {
            await botClient.SendTextMessageAsync(id, message/* replyMarkup: buttons*/);
        }

        public virtual BotResponse GetAnswer(Message message)
        {
            return new BotResponse("Возникала ошибка. Просьба обратиться к разработчику и дать ему пизды.", BotButtons.GetButtons(Common.ButtonKit.MainMenu));
        }

        public BotResponse GetError()
        {
            return new BotResponse("Придурок ты ёбаный, нормальные значения вводи", BotButtons.GetButtons(Common.ButtonKit.MainMenu));
        }
    }
}