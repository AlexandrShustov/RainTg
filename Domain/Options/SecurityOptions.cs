using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class SecurityOptions
    {
        public static string SectionName { get; set; } = "Security";

        // shouldn't be set through appsettings
        public string Key { get; set; }
    }
}
