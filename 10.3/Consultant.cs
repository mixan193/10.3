using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._3
{
    public class Consultant : IGetClient, IChangeClient
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public Consultant()
        {
            Id = 1;
            Name = "Random name";
        }
        public virtual void Handler()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вы консультант!");
                Console.WriteLine("Выберте действие:\r\n" +
                    "1. Просмотреть информацию о клиенте;\r\n" +
                    "2. Просмотреть всех клиентов\r\n");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1:
                        ChooseAMethodToFind();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(GetAllClientsInStrings(ClientsDB.clients.ToArray()));
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Вы ничего не выбрали");
                        Console.ReadKey();
                        break;
                }
            }
        }

        protected void ChooseAMethodToFind()
        {
            Client client = null;
            Console.Clear();
            Console.WriteLine("Выберте действие:\r\n" +
                "1. Поиск по ФИО;\r\n" +
                "2. Поиск по ИД\r\n" +
                "3. Поиск по номеру телефона\r\n");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Введите ФИО через пробел");
                    string[] strings = Console.ReadLine().Split(new char[] { ' ' });
                    client = ClientsDB.GetClient(strings[0], strings[1], strings[2]);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Введите ИД");
                    client = ClientsDB.GetClient(int.Parse(Console.ReadLine()));
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Введите номер телефона");
                    client = ClientsDB.GetClient(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Вы ничего не выбрали");
                    Console.ReadKey();
                    break;
            }
            if (client == null)
            {
                Console.WriteLine("Клиент не найден");
            }
            else
            {
                ChooseActionsWithClient(client);
            }
        }

        protected virtual void ChooseActionsWithClient(Client client)
        {
            Console.Clear();
            Console.WriteLine(GetClientInString(client));
            Console.WriteLine("Выберте действие:\r\n" +
                "1. Изменить номер;\r\n" +
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

        public string GetClientInString(Client client)
        {
            if (client == null)
            {
                return "Такого клиента не существует";
            }
            else
            {
                string result = string.Empty;
                result += $"ИД: {client.id}\r\n";
                result += $"Фамилия: {client.surname}\r\n";
                result += $"Имя: {client.name}\r\n";
                result += $"Отчество: {client.patronimic}\r\n";
                result += $"Номер телефона: {client.phoneNumber}\r\n";
                if (client.seriesAndNumberOfThePassport != string.Empty)
                {
                    result += "Серия и номер паспорта: **********\r\n";
                }
                else
                {
                    result += "Серия и номер паспорта: отсутствует\r\n";
                }
                result += $"Дата и время изменения записи: {client.modificationTime}\r\n";
                result += $"Было изменено: {client.modificatedData}\r\n";
                result += $"Тип изменений: {client.typeOfModification}\r\n";
                result += $"Кто менял: {client.whoChangeData}\r\n";
                return result;
            }
        }
        protected void AddClient()
        {
            int id;
            string surname;
            string name;
            string patronimic;
            string phoneNumber;
            string seriesAndNumberOfThePassport;
            if (ClientsDB.clients.Count > 0)
            {
                id = ClientsDB.clients.Last().id + 1;
            }
            else
            {
                id = 1;
            }
            Console.CursorLeft = 0;
            Console.WriteLine("Введите фамилию: ");
            surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            patronimic = Console.ReadLine();
            Console.WriteLine("Введите номер телефона: ");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Введите серию и номер паспорта: ");
            seriesAndNumberOfThePassport = Console.ReadLine();
            ClientsDB.AddClient(new Client(id, surname, name, patronimic, phoneNumber, seriesAndNumberOfThePassport, GetType().Name));
            Console.WriteLine("Пользователь добавлен");
        }
        public virtual bool ChangeClient(Client client)
        {
            if (client == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Введите новый номер: ");
                client.phoneNumber = Client.PhoneNumberUniformization(Console.ReadLine());
                client.whoChangeData = GetType().Name;
                client.modificationTime = DateTime.Now;
                client.modificatedData = "phone number";
                client.typeOfModification = "modification";
                return true;
            }
        }

        public string GetAllClientsInStrings(Client[] clients)
        {
            string result = string.Empty;
            foreach (Client client in clients)
            {
                result += GetClientInString(client);
            }
            if (result == string.Empty)
            {
                result += "Клиентов нет";
            }
            return result;
        }
    }
}
