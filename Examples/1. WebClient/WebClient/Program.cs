using System;
using System.Diagnostics;
using System.Net;

namespace WebClient
{
    class Program
    {
        const int _max = 5;
        static void Main(string[] args)
        {
            try
            {
                // Get url.
                string url = "http://edu.regi.rovno.ua/";

                // Report url.
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("... PageTimeTest: times web pages");
                Console.ResetColor();
                Console.WriteLine("Testing: {0}", url);
                
                // Fetch page.
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    // Set gzip.
                    client.Headers["Accept-Encoding"] = "gzip";

                    // Download.
                    // ... Do an initial run to prime the cache.
                    byte[] data = client.DownloadData(url);

                    // Start timing.
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    // Iterate.
                    for (int i = 0; i < Math.Min(100, _max); i++)
                    {
                        data = client.DownloadData(url);
                    }

                    // Stop timing.
                    stopwatch.Stop();

                    // Report times.
                    Console.WriteLine("Time required: {0} ms",
                        stopwatch.Elapsed.TotalMilliseconds); //повний час загрузки
                    Console.WriteLine("Time per page: {0} ms",
                        stopwatch.Elapsed.TotalMilliseconds / _max); //середній час загрузки
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("[Done]");
                Console.ReadLine();
            }
        }
    }
}
