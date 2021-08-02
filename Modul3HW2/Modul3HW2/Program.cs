using System;
using System.Globalization;
using System.IO;
using System.Text;
using Modul3HW2.Configs;
using Modul3HW2.Services;
using Newtonsoft.Json;
namespace Modul3HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new AppStarter().Run();
        }
    }
}
