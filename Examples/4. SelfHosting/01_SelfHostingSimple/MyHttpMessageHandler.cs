using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_SelfHostingSimple
{
    public class MyHttpMessageHandler : HttpMessageHandler
    {
        string contentStart = "<!DOCTYPE html><html lang='en'><head></head><body>";
        string body = "<h2>Ответ сервера Web API</h2>";
        string contentEnd = "</body></html>";

        // Метод для отправки ответа.
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Сервер получил сообщение HTTP");

            var task = new Task<HttpResponseMessage>(() =>
                {
                    var msg = new HttpResponseMessage();
                    msg.Content = new StringContent(contentStart + body + contentEnd, Encoding.UTF8, "text/html");
                    Console.WriteLine("Сервер отправляет ответ.");
                    return msg;
                });

            task.Start();

            return task;
        }
    }
}
