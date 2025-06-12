using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatika.PatternStrategyHomeWork
{
    internal class Plus: INumbers
    {
        public int Deystvie(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
