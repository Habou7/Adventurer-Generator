using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int StrengthRequirement { get; private set; }
        public int DexterityRequirement { get; private set; }
        public int ManaRequirement { get; private set; }

        public Item(string name, int strengthReq, int dexterityReq, int manaReq)
        {
            Name = name;
            StrengthRequirement = strengthReq;
            DexterityRequirement = dexterityReq;
            ManaRequirement = manaReq;
        }
    }
}