using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберте роль:\r\n" +
                "1. Консультант;\r\n" +
                "2. Менеджер\r\n");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Consultant();
                    break;
                case ConsoleKey.D2:
                    Manager();
                    break;
                default:
                    Console.CursorLeft = 0;
                    Console.WriteLine("Вы ничего не выбрали");
                    Exit();
                    break;
            }
            void Exit()
            {
                Console.ReadKey();
                Environment.Exit(0);
            }

            void Consultant()
            {
                Consultant consultant = new Consultant();
                consultant.Handler();
            }

            void Manager()
            {
                Manager manager = new Manager();
                manager.Handler();
            }
        }
    }
}
