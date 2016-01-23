using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;

namespace _01_SelfHostingSimple
{
    class Program
    {
        // Для корректной работы примера студию нужно запустить от имени Администратора.

        static void Main(string[] args)
        {
            string address = "http://localhost:8889";

            // HttpSelfHostConfiguration - классс представляет настройки для HTTP сервисов.
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(address);

            // HTTP сервис 
            HttpSelfHostServer server = new HttpSelfHostServer(config, new MyHttpMessageHandler());

            // Запуск HTTP сервиса
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Сервер успешно запущен. Получить ответ можно по адресу: {0}", address);
            Console.ReadKey();
        }
    }
}
