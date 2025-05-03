using System;
using System.Diagnostics;
using System.IO;


namespace PancakeSortt
{
    internal class CombSort
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            GeneratorData.Generator();
            string directoryPath = "InputData";
            string[] files = Directory.GetFiles(directoryPath, "*.txt");
            foreach (string file in files)
            {
                string data = File.ReadAllText(file);
                string[] numberStr = data.Split(' ');
                int[] array = Array.ConvertAll(numberStr, int.Parse);
                Console.WriteLine($"Сортировка массива из {array.Length} элеметов");

                var stopWatch = Stopwatch.StartNew();
                Sort(array);
                stopWatch.Stop();

                Console.WriteLine($"Время сортировки в милисекундах: {stopWatch.ElapsedMilliseconds } ");
                
            }
        }
        public static void Sort(int[] arr)
        {
            int passes = 0; // кол-во проходов
            int comparisons = 0; // кол-во сравнений
            int swaps = 0; //кол-во обменов

            int lenArray = arr.Length; // длина массива
            int gap = lenArray;
            bool swapped = true; // Это типа флаг была ли перестановка элеметов

            while (gap != 1 || swapped)
            {
                passes++;
                gap = Math.Max(1,(int)(gap / 1.247)); // Расстояние между проверкой элементов по индексу
                swapped = false;
                for (int i = 0; i < lenArray - gap; i++)
                {
                    comparisons++;
                    if (arr[i] > arr[i + gap])
                    {
                        swaps++;
                        int temp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = temp;
                        swapped = true;
                    }
                }
            }
            Console.WriteLine($"Кол-во проходов: {passes}");
            Console.WriteLine($"Кол-во сравнений: {comparisons}");
            Console.WriteLine($"Кол-во обменов: {swaps}");
        }
    }
}