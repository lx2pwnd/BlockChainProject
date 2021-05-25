using BlockChainClient.GenerateValue;
using System;
using System.Configuration;

namespace BlockChainClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cifrario = new Retriever()
                .EncriptString(ConfigurationManager.AppSettings["FirstString"]);

            Console.WriteLine(cifrario);
            Console.ReadLine();
        }
    }
}
