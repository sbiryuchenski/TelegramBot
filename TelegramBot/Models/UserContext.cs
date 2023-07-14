using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Bot
{
    public class UserContext
    {
        public long SenderId { get; set; } = 0;
        public long RecieverId { get; set; } = 0;
        public UserContext() 
        {
            
        }
    }
}
