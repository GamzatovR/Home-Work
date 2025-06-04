using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informatika
{
    class Program
    {
        static void Main(string[] args)
        {
            //DZ_Mnogopotochka dz = new DZ_Mnogopotochka();
            //dz.SummaArray();
            //DZBezMnogopotocki dz2 = new DZBezMnogopotocki();
            //dz2.BezMnogopotokov();
            ChtoPopalo chtoPopalo = new ChtoPopalo();
            chtoPopalo.ChtoPopalos();
        }
}
}