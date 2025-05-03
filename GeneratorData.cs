using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSortt
{
    internal class GeneratorData
    {
        public static void Generator()
        {
            string directoryPath = "InputData"; //Это папка данных
            Directory.CreateDirectory(directoryPath); // Это создаём саму папку

            Random random = new Random();
            int dataSetCount = 50; // Это кол-во наборов данных
            for (int i = 0; i < dataSetCount; i++)
            {
                int size = random.Next(100, 10000); //Кол-во элеметов в наборе
                int[] array = new int[size];
                for (int j = 0; j < size; j++)
                {
                    array[j] = random.Next(10000); // На каждый элемент, создаётся число диапазоном от 0 до 10 000
                }
                string filePath = Path.Combine(directoryPath, $"dataset_{i + 1}.txt"); //Путь к файлу
                File.WriteAllText(filePath, string.Join(" ", array)); // Создаётся текстовый файл
                Console.WriteLine($"Создан dataset_{i + 1}.txt с {size} количесвом элементов");
            }
            Console.WriteLine("Данные сгенерированы");
        }
    }
}
