using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _10._3
{
    public static class ClientsDB
    {
        public static List<Client> clients = new List<Client>();
        public static int GetCount { get { return clients.Count; } }
        static ClientsDB()
        {
            if (File.Exists("DB.dat"))
            {
                FileStream fs = new FileStream("DB.dat", FileMode.Open, FileAccess.Read);
                clients = (List<Client>)new BinaryFormatter().Deserialize(fs);
            }
        }
        public static int AddClient(Client client)
        {
            clients.Add(client);
            FileStream fs = new FileStream("DB.dat", FileMode.OpenOrCreate, FileAccess.Write);
            new BinaryFormatter().Serialize(fs, clients);
            fs.Close();
            return clients.Count;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по имени, фамилии и отчеству
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronimic"></param>
        /// <returns></returns>
        public static Client GetClient(string surname, string name, string patronimic)
        {
            foreach (Client client in clients)
            {
                if (client.surname == surname)
                {
                    if (client.name == name)
                    {
                        if (client.patronimic == patronimic)
                        {
                            return client;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static Client GetClient(string phoneNumber)
        {
            foreach (Client client in clients)
            {
                if (client.phoneNumber == Client.PhoneNumberUniformization(phoneNumber))
                {
                    return client;
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по номеру ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Client GetClient(int id)
        {
            foreach (Client client in clients)
            {
                if (client.id == id)
                {
                    return client;
                }
            }
            return null;
        }

    }
}
