using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Configs;
using Modul3HW2.Enums;
using Modul3HW2.Models;
using Modul3HW2.Services.Abstractions;
using Newtonsoft.Json;
namespace Modul3HW2.Services
{
    public class ConfigService : IConfigService
    {
        private const string _path = "config.json";
        private Config _config;
        public ConfigService()
        {
            Init();
        }

        public Alphabet Rus => _config.AlphabetConfig.Russian;
        public Alphabet Eng => _config.AlphabetConfig.English;
        public Alphabet Default => _config.AlphabetConfig.Default;
        public Config Config => _config;
        public NamePriority NamePriority => _config.ContactConfig.Priority;
        public void Init()
        {
            var str = File.ReadAllText(_path);
            _config = JsonConvert.DeserializeObject<Config>(str);
        }

        public Alphabet GetAlphabet(CultureInfo culture)
        {
            if (culture.Name == "ru-RU")
            {
                return Rus;
            }
            else if (culture.Name == "en-US")
            {
                return Eng;
            }
            else
            {
                return Default;
            }
        }
    }
}
