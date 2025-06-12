using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatika
{
    public class ConfigService
    {
        public string ConfigData { get; private set; }
        private ConfigService() { }
        public static async Task<ConfigService> CreateAsync(string filePath)
        {
            var service = new ConfigService();
            await service.LoadAsync(filePath);
            return service;
        }

        private async Task LoadAsync(string filePath)
        {
            await Task.Delay(1000);
            ConfigData = $"Конфигурация из файла: {filePath}";
        }
    }

    internal class DZAsync_3
    {
        public async Task UseConfigServiceAsync()
        {
            var config = await ConfigService.CreateAsync("config.json");

            Console.WriteLine(config.ConfigData);
        }
    }
}
