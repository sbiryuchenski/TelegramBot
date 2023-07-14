using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    class MessageSender : BaseDialog
    {
        public BotResponse SendMessageToUser(ITelegramBotClient botClient, Message message, UserContext user)
        {
            SendMessageToUser(botClient, user.RecieverId, $"Сообщение от пользователя {message.Chat.Username} | {message.Text}"/*, null*/);
            BotResponse answer = new BotResponse();
            answer.Message = "Сообщение отправлено!";
            answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.MainMenu);
            return answer;
        }
    }
}
