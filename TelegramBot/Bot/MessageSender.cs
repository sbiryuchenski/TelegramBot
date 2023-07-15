using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DataBase;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    class MessageSender : BaseDialog
    {
        public BotResponse SendMessageToUser(ITelegramBotClient botClient, Message message, UserContext user)
        {
            BotResponse answer = new BotResponse();
            answer.Message = "Сообщение отправлено!";
            answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.MainMenu);

            if (message.Text.ToLower() == "назад")
            {
                answer.Message = "Что ж ты фраер сдал назад";
                MenuMapper.ActiveUsers.Remove(MenuMapper.ActiveUsers.Where(_ => _.SenderId == message.Chat.Id).First());
            }
            else
            {
                SendMessageToUser(botClient, user.RecieverId, $"Сообщение от пользователя {DBase.GetUsers().Where(_=>_.UserId == message.Chat.Id).Select(_=>_.UserName).First().TrimEnd()} | {message.Text}"/*, null*/);
                MenuMapper.ActiveUsers.Remove(MenuMapper.ActiveUsers.Where(_ => _.SenderId == message.Chat.Id).First());
            }
            return answer;
        }
    }
}
