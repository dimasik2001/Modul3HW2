using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul3HW2.Enums;
using Modul3HW2.Models;

namespace Modul3HW2.Services.Abstractions
{
    public interface IConfigService
    {
        public Alphabet Default { get; }
        public NamePriority NamePriority { get; }
        public void Init();
        public Alphabet GetAlphabet(CultureInfo culture);
    }
}
