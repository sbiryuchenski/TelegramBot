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
                    answer.Message = "Выбери человека, которому хочешь отправить сообщение";
                    break;
                case "пойти нахуй":
                    answer.Message = "Ну так иди нахуй, хули сидишь";
                    break;
                case "назад":
                    answer.Message = "Ёбаный рот этого казино. блять.";
                    break;
                default:
                    answer.Message = "Это замечательно, что ты умеешь печатать, но нажми пожалуйста на кнопочку, долбоёб.";
                    break;
            }
            return answer;
        }
    }
}
