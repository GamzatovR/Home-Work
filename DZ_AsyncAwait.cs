using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Informatika
{
    class Program
    {
        static async Task Main()
        {
            List<string> url = new List<string>()
            {
                "https://google.com",
                "https://yandex.ru",
                "https://e.mail.ru"
            };

            string[] adresa = await SpisokURL(url);
        }
        public static async Task<string[]> SpisokURL(List<string> urls)
        {
            HttpClient httpClient = new HttpClient();
            string[] urli = new string[urls.Count];
            try
            {
                Task<string>[] downloadsTasks = new Task<string>[urls.Count];
                for(int i = 0; i < urls.Count; i++)
                {
                    downloadsTasks[i] = httpClient.GetStringAsync(urls[i]);
                }
                urli = await Task.WhenAll(downloadsTasks);
                return urli;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Вышла ошибка: {ex}");
                return null;
            }
        }
    }
}
