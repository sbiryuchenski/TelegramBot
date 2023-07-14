using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Telegram.Bot;
using TelegramBot.Common;
using TelegramBot.DataBase;
using Microsoft.VisualBasic;
using System;
using Telegram.Bot.Types.ReplyMarkups;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using TelegramBot.Models;
using Microsoft.EntityFrameworkCore.Storage;
using TelegramBot.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Bot
{
    /// <summary>
    /// Класс для работы с ботом
    /// </summary>
    public static class Bot
    {
        static Settings settings;
        static TelegramBotClient client { get; set; }
        static MenuMapper menuMapper { get; set; }

        public static void Init(Settings set)
        {
            settings = set;
            client = new TelegramBotClient(settings.Token);
            menuMapper = new();
        }
        public async static Task StartReceiving() // Запускает  получение данных с бота
        {
            await Task.Run(() => client.StartReceiving(Update, Error));
        }
        private async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken) // Асинхронное взаимодействие с ботом
        {
            var message = update.Message;

            if (message.Text != null)
            {
                BotResponse answer = menuMapper.GetAnswer(message, botClient);
                BaseDialog.SendMessageToUser(botClient, message.Chat.Id, $"Сообщение от пользователя {message.Chat.Username} | {message.Text}"/*, null*/);
            }
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

    }
}
