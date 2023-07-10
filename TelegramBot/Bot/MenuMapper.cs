using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Telegram.Bot.Types;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    class MenuMapper
    {
        static List<UserContext> activeUsers;
        MainMenu mainMenu;

        public MenuMapper()
        {
            mainMenu = new MainMenu();
            activeUsers = new List<UserContext>();
        }

        public BotResponse GetAnswer(Message message)
        {
            string answer = "";
            var auser = activeUsers.Select(_ => _).Where(_ => _.SenderId == message.Chat.Id).FirstOrDefault();
            if (auser == null)
            {
                mainMenu.GetAnswer(message);

                activeUsers.Add(auser);
                auser = new UserContext();
                auser.SenderId = message.Chat.Id;
            }
            else
            {
                if (auser.RecieverId == 0)
                {
                    try
                    {
                        Int64.TryParse(message.Text, out var reciever);
                        auser.RecieverId = Convert.ToInt64(message.Text);
                    }
                    catch
                    {
                        answer = "Еблан тупой блять";
                    }
                }
                else
                {

                }
            }
            string mes = message.Text.ToLower();
            switch (mes)
            {
                case "отправить сообщение":
                    mainMenu.GetAnswer(message);
                    break;
                case "пойти нахуй":
                    mainMenu.GetAnswer(message);
                    break;
            }

            return null;
        }
    }
}
