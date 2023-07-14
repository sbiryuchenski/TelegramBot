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
    public class SelectUserMenu : BaseDialog
    {
        public override BotResponse GetAnswer(Message message)
        {
            BotResponse answer = new();
            var recieverId = DBase.GetUsers().Where(_ => _.UserName == message.Text).Select(_ => _.UserId).FirstOrDefault();
            if (recieverId != 0)
            {
                MenuMapper.ActiveUsers.Where(_ => _.SenderId == message.Chat.Id).Select(_ => _).First().RecieverId = recieverId;
                answer.Message = "Введите сообщение";
                answer.Buttons = BotButtons.GetButtons(Common.ButtonKit.Back);
            }
            else
            {
                answer = GetError();
            }
            return answer;
        }
    }
}
