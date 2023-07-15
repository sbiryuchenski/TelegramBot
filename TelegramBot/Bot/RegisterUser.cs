using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.DataBase;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    public static class RegisterUser
    {
        public static BotResponse Register(TelegramBot.Models.User user)
        {
            var answer = new BotResponse();
            answer.Message = "Нахуя ты второй раз регистрируешься ебень";
            answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.MainMenu);

            var prepareToRegister = DBase.GetUsers().Where(_ => _.UserId.ToString() == user.UserId.ToString()).FirstOrDefault();
            if(prepareToRegister == null)
            {
                DBase.AddToDb(user);
                answer.Message = "АХАХАХА ищи себя в прошмандовках моей базы данных";
            }
            return answer;
        }
    }
}
