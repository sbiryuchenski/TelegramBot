using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models;

namespace TelegramBot.Bot
{
    public class MenuMapper
    {
        public static List<UserContext> ActiveUsers;
        MainMenu mainMenu;
        SelectUserMenu selectUserMenu;
        MessageSender messageSender;
        public MenuMapper()
        {
            mainMenu = new MainMenu();
            selectUserMenu = new SelectUserMenu();
            messageSender = new MessageSender();
            ActiveUsers = new List<UserContext>();
        }

        public BotResponse GetAnswer(Message message, ITelegramBotClient botClient)
        {
            UserContext user = null;
            try { user = ActiveUsers.Where(_ => _.SenderId == message.Chat.Id).FirstOrDefault(); }
            catch {  }
            string mes = message.Text.ToLower();
            BotResponse answer = new();

            if (user == null)
            {
                answer = mainMenu.GetAnswer(message);
            }
            else
            {
                if (user.SenderId != 0 && user.RecieverId == 0)
                {
                   answer = selectUserMenu.GetAnswer(message);
                }
                else
                {
                    if(user.RecieverId != 0)
                    {
                        answer = messageSender.SendMessageToUser(botClient, message, user);
                    }
                }
                //answer = mainMenu.GetError();
            }

            switch (mes)
            {
                case "отправить сообщение":
                    
                    break;
                case "пойти нахуй":
                    mainMenu.GetAnswer(message);
                    break;
            }

            return answer;
        }
    }
}
