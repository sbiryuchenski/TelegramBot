using Microsoft.VisualBasic;
using System;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;
using System.IO;
using TelegramBot.Common;
using Newtonsoft.Json;
using TelegramBot.Models;
using Microsoft.EntityFrameworkCore.Storage;
using TelegramBot.DataBase;
using TelegramBot.Bot;

namespace TestGovnobot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Settings Settings;
            Settings = JsonConvert.DeserializeObject<Settings>(System.IO.File.ReadAllText("AppSettings.json"));
           // DBase db = new (Settings);
            Bot.Init(Settings);
            DBase.InitDataBase(Settings);

            await Task.Run(() => Bot.StartReceiving());

            Console.ReadLine();
        }

        
        //private static IReplyMarkup GetMainButtons()
        //{
        //    var k = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { new List<KeyboardButton> { new KeyboardButton("Отправить сообщение"), new KeyboardButton("Пойти нахуй") } })
        //    {
        //    };
        //    k.ResizeKeyboard = true;
        //    return k;
        //}
        //private static IReplyMarkup GetBackButton()
        //{
        //    var k = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { new List<KeyboardButton> { new KeyboardButton("Назад") } })
        //    {
        //    };
        //    k.ResizeKeyboard = true;
        //    return k;
        //}
        //private static IReplyMarkup GetUsersListButtons()
        //{
        //    var kblist = new List<KeyboardButton>();
        //    foreach (var u in UserList.Users)
        //    {
        //        kblist.Add(new KeyboardButton(u.Name));
        //    }
        //    var k = new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { kblist });
        //    k.ResizeKeyboard = true;
        //    return k;
        //}
    }
}
