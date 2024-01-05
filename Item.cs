using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprata_TextRPG
{
    enum ItemType
    {
        Weapon,
        Armor
    }
    internal class Item
    {
        public string equipMsg ;// 장착시 표시할 문자 [E]
        public string itemName; // 아이템 이름
        public int option; // 옵션
        public string optionText; // 공격력,방어력 표시
        public ItemType itemType; // 타입
        public string itemInfo; // 아이템 설명
        public int buyGold; // 살때 필요한 골드
        public int sellGold;

        public bool isBuy; // 이미 구매했는지?
        public bool isEquip; // 장착했는지?

        public Item(string _itemName, int _option, ItemType _itemType, string _itemInfo, int _buyGold) //아이템 클래스 생성자
        {
            itemName = _itemName;
            option = _option;
            itemType = _itemType;
            if(_itemType == ItemType.Weapon )
            {
                optionText = "공격력";
            }
            else
            {
                optionText = "방어력";
            }
            itemInfo = _itemInfo;
            buyGold = _buyGold;
            sellGold = (int)(_buyGold * 0.85);

        }


        


    }
}
