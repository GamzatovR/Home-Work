using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informatika
{
    class Smstyat_Potochka
    {
        public void Samostoyat()
        {
            Random rnd = new Random();
            List<BankAccount> bankAccounts = new List<BankAccount> { };
            for (int i = 0; i < 10; i++)
            {
                bankAccounts.Add(new BankAccount(rnd.Next(1000, 5000)));
            }
            Thread[] thread = new Thread[20];
            for (int i = 0; i < thread.Length; i++)
            {
                thread[i] = new Thread(() => Translate(bankAccounts));
                thread[i].Start();
            }
        }
        public void Translate(List<BankAccount> bankAccount)
        {
            //object _lockobj = new();
            Random rnd = new Random();
            int count = 0;
            //lock(locker)
            {
                for (int i = 0; i < 1000; i++)
                {
                    int trans = rnd.Next(1, 501);
                    int schet1 = rnd.Next(0, 10);
                    int schet2 = rnd.Next(0, 10);
                    if (schet1 != schet2 && bankAccount[schet1].balance - trans >= 0 && bankAccount[schet2].balance >= trans)
                    {
                        bankAccount[schet1].balance -= trans;
                        bankAccount[schet2].balance += trans;
                        count++;
                    }
                }
            }
        }
    }
    class BankAccount
    {
        public int balance { get; set; }
        public BankAccount(int balance)
        {
            this.balance = balance;
        }
    }
}
