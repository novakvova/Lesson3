using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace PostRequestWevClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //создание объекта web-клиент 
            WebClient client= new WebClient();
            string TextToUpload = "User=Vasia&passwd=okna", urlString = "http://localhost/"; 
           // Преобразуем текст в массив байтов 
           byte[] uploadData=Encoding.ASCII.GetBytes(TextToUpload); 
           // связываем URL с потоком записи 
           Stream upload=client.OpenWrite(urlString,"POST");  
           // загружаем данные на сервер 
           upload.Write(uploadData,0,uploadData.Length); 
           upload.Close(); 
            WebClient clientUp= new WebClient();
            //WebClient client= new WebClient(); 
            clientUp.Credentials = System.Net.CredentialCache.DefaultCredentials; 
              // добавляем HTTP-заголовок 
           clientUp.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
           // Преобразуем текст в массив байтов 
           // копируем данные методом GET 
           byte[] respText=client.UploadData(urlString,"GET",uploadData);  
           // загружаем данные на сервер 
           upload.Write(uploadData,0,uploadData.Length); 
           upload.Close(); 
        }
    }
}
