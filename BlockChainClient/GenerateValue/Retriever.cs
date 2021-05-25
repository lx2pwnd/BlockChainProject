using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainClient.GenerateValue
{
    public class Retriever : IRetriever
    {
        private int GenerateValue()
               => new Random().Next(
                   new Random().Next(-84, 0), new Random().Next(0, 84)
                   );

        private Dictionary<int, char> GenerateAlphabet()
            => new Dictionary<int, char>(){
                {1,'A'},
                {2,'B'},
                {3,'C'},
                {4,'D'},
                {5,'E'},
                {6,'F'},
                {7,'G'},
                {8,'H'},
                {9,'I'},
                {10,'J'},
                {11,'K'},
                {12,'L'},
                {13,'M'},
                {14,'N'},
                {15,'O'},
                {16,'P'},
                {17,'Q'},
                {18,'R'},
                {19,'S'},
                {20,'T'},
                {21,'U'},
                {22,'V'},
                {23,'W'},
                {24,'X'},
                {25,'Y'},
                {26,'Z'},
                {27,' '},
                {29,'('},
                {30,')'},
                {31,'\\'},
                {32,'/'},
                {33,'['},
                {34,']'},
                {35,'{'},
                {36,'}'},
                {37,'?'},
                {38,'#'},
                {39,'%'},
                {40,'$'},
                {41,'£'},
                {42,'&'},
                {43,'a'},
                {44,'b'},
                {45,'c'},
                {46,'d'},
                {47,'e'},
                {48,'f'},
                {49,'g'},
                {50,'h'},
                {51,'i'},
                {52,'j'},
                {53,'k'},
                {54,'l'},
                {55,'m'},
                {56,'n'},
                {57,'o'},
                {58,'p'},
                {59,'q'},
                {60,'r'},
                {61,'s'},
                {62,'t'},
                {63,'u'},
                {64,'v'},
                {65,'w'},
                {66,'x'},
                {67,'y'},
                {68,'z'},
                {69,'.'},
                {70,'-'},
                {71,'-'},
                {72,'_'},
                {73,':'},
                {74,';'},
                {75,'0'},
                {76,'1'},
                {77,'2'},
                {78,'3'},
                {79,'4'},
                {80,'5'},
                {81,'6'},
                {82,'7'},
                {83,'8'},
                {84,'9'},
            };

        public string EncriptString(string str)
        {
            var alphabet = GenerateAlphabet();

            var encryptedString = string.Empty;

            var salt = GenerateValue();

            foreach (char c in str)
            {
                var index = alphabet.Where(letter => letter.Value == c)
                    .Select(pair => pair.Key)
                    .FirstOrDefault();

                var encryptedChar = alphabet.FirstOrDefault(x => x.Key == index + salt).Value;

                encryptedString = String.Concat(encryptedString, encryptedChar);
            }

            return encryptedString;
        }
    }
}
