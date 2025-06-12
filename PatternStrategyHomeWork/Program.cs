using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Informatika.PatternStrategyHomeWork
{
    internal class Program
    {
        public static void Main()
        {
            public string enter = Console.ReadLine();
            string[] ent = enter.Split(' ');
            int num1 = int.Parse(ent[0]);
            int num2 = int.Parse(ent[2]);

            switch(ent[1])
            {
                case "+":
                    Calculator.Operation(new Plus());
                    Console.WriteLine(Calculator.Values(num1, num2));
                    break;
                case "-":
                    Calculator.Operation(new Minus());
                    Console.WriteLine(Calculator.Values(num1, num2));
                    break;
                case "*":
                    Calculator.Operation(new Umnozhenie());
                    Console.WriteLine(Calculator.Values(num1, num2));
                    break;
                case "/":
                    Calculator.Operation(new Umnozhenie());
                    Console.WriteLine(Calculator.Values(num1, num2));
                    break;
            }
        }
    }
    class Calculator
    {
        public static INumbers typeOperation;
        public static void Operation(INumbers oper)
        {
            typeOperation = oper;
        }
        public static int Values(int num1, int num2)
        {
            return typeOperation.Deystvie(num1, num2);
        }
    }
}
