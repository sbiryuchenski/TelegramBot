using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Models;

namespace TelegramBot.Common
{
    class BaseContext : DbContext // Контекст базы данных
    {
        string connectionString;
        public BaseContext(Settings settings)
        {
            connectionString = settings.Database;
            //SqlConnectionStringBuilder a = new();
            //a.DataSource = "localhost\\SQLEXPRESS;

        }
        public DbSet<User> Users { get; set; } = null!; // Объект для доступа к таблице Users. Для других таблиц написать по образу и подобию

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Настройка бд
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
