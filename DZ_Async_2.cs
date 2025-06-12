using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatika
{
    public class DeadlockExample
    {
        public string GetData()
        {
            return GetDataAsync().Result;
        }

        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1000);
            return "Данные получены";
        }
    }

}
