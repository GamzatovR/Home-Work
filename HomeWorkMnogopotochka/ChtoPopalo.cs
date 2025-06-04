using System;
using System.Collections.Generic;
using System.Threading;

namespace Informatika
{
    class ChtoPopalo
    {
        public void ChtoPopalos()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Print,i);
            }
            Thread.Sleep(3000);
        }
        static void Print(object state)
        {
            Console.WriteLine($"Номер задачи: {state}");
            Console.WriteLine($"ID потока в котором выполняется задача: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("-------------------");
            Thread.Sleep(1000);
        }
    }
}