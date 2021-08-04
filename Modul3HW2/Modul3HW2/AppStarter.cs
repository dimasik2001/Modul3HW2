using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Modul3HW2.Providers;
using Modul3HW2.Services;
using Modul3HW2.Services.Abstractions;

namespace Modul3HW2
{
    public class AppStarter
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IContactService, ContactService>()
                .AddTransient<ContactProvider>()
                .AddTransient<Starter>().BuildServiceProvider();
            serviceProvider.GetService<Starter>().Run();
        }
    }
}
