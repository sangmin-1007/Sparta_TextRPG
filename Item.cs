using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprata_TextRPG
{
    internal class Item
    {
        public string itemName;
        public int option;
        public string itemType;
        public string itemInfo;

        public Item(string _itemName, int _option, string _itemType, string _itemInfo)
        {
            itemName = _itemName;
            option = _option;
            itemType = _itemType;
            itemInfo = _itemInfo;

        }

        


    }
}
