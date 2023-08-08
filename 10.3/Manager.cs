using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10._3
{
    internal class Manager : Consultant
    {
        public Manager()
        {
            Id = 2;
            Name = "Random name";
        }

        public override void Handler()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вы менеджер!");
                Console.WriteLine("Выберте действие:\r\n" +
                    "1. Просмотреть информацию о клиенте;\r\n" +
                    "2. Просмотреть всех клиентов\r\n" +
                    "3. Добавить клиента");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1:
                        ChooseAMethodToFind();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(GetAllClientsInStrings(ClientsDB.clients.ToArray()));
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        AddClient();
                        break;
                    default:
                        Console.WriteLine("Вы ничего не выбрали");
                        break;
                }
            }
        }

        protected override void ChooseActionsWithClient(Client client)
        {
            Console.Clear();
            Console.WriteLine(GetClientInString(client));
            Console.WriteLine("Выберте действие:\r\n" +
                "1. Изменить данные;\r\n" +
                "2. Выход\r\n");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1:
                    ChangeClient(client);
                    break;
                default:
                    break;
            }

        }


        public override bool ChangeClient(Client client)
        {
            if (client == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Введите новую фамилию: ");
                client.surname = Client.PhoneNumberUniformization(Console.ReadLine());
                Console.WriteLine("Введите новое имя: ");
                client.name = Client.PhoneNumberUniformization(Console.ReadLine());
                Console.WriteLine("Введите новое отчество: ");
                client.patronimic = Client.PhoneNumberUniformization(Console.ReadLine());
                Console.WriteLine("Введите новый номер: ");
                client.phoneNumber = Client.PhoneNumberUniformization(Console.ReadLine());
                Console.WriteLine("Введите новые серию и номер паспорта: ");
                client.seriesAndNumberOfThePassport = Client.PhoneNumberUniformization(Console.ReadLine());
                client.whoChangeData = GetType().Name;
                client.modificationTime = DateTime.Now;
                client.modificatedData = "All data";
                client.typeOfModification = "modification";

                return true;
            }
        }
    }
}
