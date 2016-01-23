using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace _02_SelfHostingWithRoutingAndControllers
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "http://localhost:8889";

            // Создание объекта настроек.
            var config = new HttpSelfHostConfiguration(address);

            // Определение маршрута который будет использовать сервис
            config.Routes.MapHttpRoute(
                "MyRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            // Создание сервиса
            var server = new HttpSelfHostServer(config);

            // Запуск сервиса
            var task = server.OpenAsync();
            task.Wait();

            Console.WriteLine("Сервис доступен по адресу {0}/api/my", address);
            Console.ReadKey();
        }
    }
}
