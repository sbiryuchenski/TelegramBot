using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Common;
using TelegramBot.Models;


namespace TelegramBot.DataBase
{
    /// <summary>
    /// Класс для работы с бд через энтити
    /// </summary>
    public static class DBase
    {
        static BaseContext db { get; set; }// Объект бд
        public static void InitDataBase(Settings settings)
        {
            db = new BaseContext(settings);
        }

        /// <summary>
        /// Добавить запись в базу
        /// </summary>
        public static void AddToDb(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static DbSet<User> GetUsers() => db.Users; // Получить таблицу Users в виде объекта

    }
}
