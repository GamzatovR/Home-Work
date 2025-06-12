using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace Informatika
{
    internal class DZ_Mnogopotochka
    {
        private readonly object locker = new object();
        public void SummaArray()
        {
            var stopWatch = Stopwatch.StartNew();
            Random rand = new Random();
            int sizeArray = Convert.ToInt32(Math.Pow(10, 3));
            int[] array = new int[sizeArray];
            int chunkSize = sizeArray / 100; // каждая часть по 10 элементов

            var chunks = new List<int[]>();

            for (int i = 0; i < sizeArray; i++)
                array[i] = rand.Next(101);

            for (int j = 0; j < sizeArray; j += chunkSize)
            {
                int size = Math.Min(chunkSize, sizeArray - j);
                int[] chunk = new int[size];
                Array.Copy(array, j, chunk, 0, size);
                chunks.Add(chunk);
            }
            int sumAllPart = 0;
            Thread osnovnoy = new Thread(() => Console.WriteLine(sumAllPart));
            Thread[] threads = new Thread[100];
            lock (locker)
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    lock(locker)
                    {
                        threads[i] = new Thread(() =>
                        {
                            int sumPart = 0;
                            for (int a = 0; a < chunkSize; a++)
                            {
                                sumPart += chunks[i][a];
                                sumAllPart += chunks[i][a];
                            }
                            Console.WriteLine($"Массив {i}, сумма: {sumPart}");
                        }
                        );
                        threads[i].Start();
                    }
                }
            }
            osnovnoy.Start();
            stopWatch.Stop();
            Console.WriteLine($"Точное время: {stopWatch.Elapsed.TotalMilliseconds} мс");
        }
    }
}
