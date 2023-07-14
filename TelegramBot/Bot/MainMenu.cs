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
    class MainMenu : BaseDialog
    {
        public override BotResponse GetAnswer(Message message)
        {
            BotResponse answer = new();
            switch (message.Text.ToLower())
            {
                case "отправить сообщение":
                    answer = SendMessage(message);
                    break;
                case "пойти нахуй":
                    answer.Message = "Ну так иди нахуй, хули сидишь";
                    break;
                case "назад":
                    answer = Back(message);
                    break;
                default:
                    answer.Message = "Это замечательно, что ты умеешь печатать, но нажми пожалуйста на кнопочку, долбоёб.";
                    break;
            }
            return answer;
        }
        private BotResponse SendMessage(Message message)
        {
            var auser = MenuMapper.ActiveUsers.Select(_ => _).Where(_ => _.SenderId == message.Chat.Id).FirstOrDefault();
            if (auser == null)
            {
                MenuMapper.ActiveUsers.Add(auser);
                auser = new UserContext();
                auser.SenderId = message.Chat.Id;
            }

            BotResponse answer = new();
            answer.Message = "Выбери человека, которому хочешь отправить сообщение";
            answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.UserList);
            return answer;
        }
        private BotResponse Back(Message message)
        {
            var auser = MenuMapper.ActiveUsers.Select(_ => _).Where(_ => _.SenderId == message.Chat.Id).FirstOrDefault();

            if (auser is not null)
            {
                MenuMapper.ActiveUsers.Remove(auser);
            }
            BotResponse answer = new();
            answer.Message = "Ёбаный рот этого казино. блять.";
            answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.Back);
            return answer;
        }
    }
}
