using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class TelegramOptions
    {
        public static string SectionName { get; set; } = "Telegram";
        public string Token { get; set; }
        public string WebhookUrl { get; set; }
    }
}
