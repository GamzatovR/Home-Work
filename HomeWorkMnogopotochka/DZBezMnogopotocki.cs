using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informatika
{
    internal class DZBezMnogopotocki
    {
        public void BezMnogopotokov()
        {
            var stopWatch = Stopwatch.StartNew();
            Random rand = new Random();

            int[] array = new int[1000];
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(101);
                sum += array[i];
            }
            Console.WriteLine($"Сумма массива: {sum}");
            stopWatch.Stop();
            Console.WriteLine($"Точное время: {stopWatch.Elapsed.TotalMilliseconds} мс");
        }
    }
}
