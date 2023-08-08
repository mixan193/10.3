using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._3
{
    internal interface IGetClient
    {
        string GetClientInString(Client client);
        string GetAllClientsInStrings(Client[] clients);
    }
}
