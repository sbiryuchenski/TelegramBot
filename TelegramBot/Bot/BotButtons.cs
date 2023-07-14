using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Common;
using TelegramBot.DataBase;

namespace TelegramBot.Bot
{
    public class BotButtons
    {
        public static IReplyMarkup GetButtons(ButtonKit kit)
        {
            IReplyMarkup keyboard = null;
            switch (kit)
            {
                case ButtonKit.MainMenu:
                    keyboard = GetMainMenuButtons();
                    break;
                case ButtonKit.UserList:
                    keyboard = GetUsersButtons();
                    break;
                case ButtonKit.Back:
                    keyboard = GetBackButton();
                    break;
            }
            try
            {
                return keyboard;
            }
            catch
            {
                return GetMainMenuButtons();
            }
        }
        private static IReplyMarkup GetMainMenuButtons()
        {
            var k = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { new List<KeyboardButton> { new KeyboardButton("Отправить сообщение"), new KeyboardButton("Пойти нахуй") } })
            {
            };
            k.ResizeKeyboard = true;
            return k;
        }
        private static IReplyMarkup GetUsersButtons()
        {
            var users = DBase.GetUsers().Select(_ => _.UserName).ToList();
            var uRow = new List<KeyboardButton>();
            var keyboard = new List<List<KeyboardButton>>();
            for (int i = 0; i < users.Count; i++)
            {
                if (i % 5 == 4)
                {
                    keyboard.Add(new List<KeyboardButton>());
                }
                    keyboard[keyboard.Count].Add(new KeyboardButton(users[i]));
            }
            var k = new ReplyKeyboardMarkup(keyboard);
            k.ResizeKeyboard = true;
            return k;
        }
        private static IReplyMarkup GetBackButton()
        {
            var k = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { new List<KeyboardButton> { new KeyboardButton("Назад") } })
            {
            };
            k.ResizeKeyboard = true;
            return k;
        }
    }
}
