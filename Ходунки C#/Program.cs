using System;

namespace Hodunki
{
    class Program
    {
        static void Main()
        {
            void GetRectangleData(in int width, int height, out int rectArea, out int rectPerimetr)
            {
                width = 25; // нельзя изменить, так как width - входной параметр
                rectArea = width * height;
                rectPerimetr = (width + height) * 2;
            }

            GetRectangleData(10, 20, out var area, out var perimetr);

            Console.WriteLine($"Площадь прямоугольника: {area}");       // 200
            Console.WriteLine($"Периметр прямоугольника: {perimetr}");   // 60
        }
    }
}