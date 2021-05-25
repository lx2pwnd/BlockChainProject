using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainClient.GenerateValue
{
    public interface IRetriever
    {
        public string EncriptString(string str);
    }
}
