using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Common
{
    public class Settings
    {
        public string Database { get; set; }
        public string Token { get; set; }
    }
}
