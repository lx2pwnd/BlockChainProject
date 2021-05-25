using System;

namespace BlockChainAPI
{
    public class Block
    {
        public string BlockValueString { get; set; }
        public int BlockNumberID { get; set; }
        public int SaltUsing { get; set; }
        public bool IsGenerated { get; set; }
    }
}
