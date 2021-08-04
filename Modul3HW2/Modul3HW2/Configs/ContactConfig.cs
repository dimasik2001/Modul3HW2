using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Modul3HW2.Enums;
using Newtonsoft.Json.Converters;

namespace Modul3HW2.Configs
{
    public class ContactConfig
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NamePriority Priority { get; set; }
    }
}
