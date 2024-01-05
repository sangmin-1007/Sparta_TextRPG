using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprata_TextRPG
{
    internal class Shop
    {
        

        List<Item> items = new List<Item>();


        


        public void AddShopItem(Item item)
        {
            items.Add(item);
        }

        public void Shopinfo(Player player)
        {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.gold}");

            Console.WriteLine("[아이템 목록]");
            for(int i = 0 ; i < items.Count; i++)
            {
                if (items[i].isBuy == true)
                {
                    Console.WriteLine($"- {items[i].itemName,-10}| {items[i].optionText} + {items[i].option}    | {items[i].itemInfo,-40}    | 구매완료.");
                }
                else
                    Console.WriteLine($"- {items[i].itemName,-10}| {items[i].optionText} + {items[i].option}    | {items[i].itemInfo,-40}    | {items[i].buyGold} G");

            }


            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.Clear();
                    Shopping(player);
                    break;
                case"2":
                    Console.Clear();
                    SellShopping(player);
                    //판매 기능 추가
                    break;
                case "0":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("다시 입력해주세요");
                    Shopinfo(player);
                    break;
            }
        }

        private void Shopping(Player player)
        {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.gold}");

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].isBuy == true)
                {
                    Console.WriteLine($"-{i+1} {items[i].itemName,-10}| {items[i].optionText} + {items[i].option,10}    | {items[i].itemInfo,30}    | 구매완료.");
                }
                else
                    Console.WriteLine($"-{i+1} {items[i].itemName,-10}| {items[i].optionText} + {items[i].option,10}    | {items[i].itemInfo,30}    | {items[i].buyGold} G");

            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();
            int inputNum = 0;
            inputNum = int.TryParse(input, out inputNum) ? inputNum : -1;

            if(inputNum == 0) 
            {
                Console.Clear();
                Shopinfo(player);
            }
            else if( inputNum < 0)  // 이상한 번호를 타이핑 했을때
            {
                Console.Clear() ;
                Console.WriteLine("다시 입력해주세요");
                Shopping(player);
            }
            else if(inputNum -1 < items.Count)
            {
                if (items[inputNum-1].buyGold <= player.gold)
                {
                    items[inputNum - 1].isBuy = true;
                    player.gold -= items[inputNum - 1].buyGold;
                    player.AddInven(items[inputNum - 1]);
                    Console.Clear();
                    Console.WriteLine("구매되었습니다!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("구매할 수 없습니다.");
                }

                Shopping(player);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("잘못 입력하셨습니다.");
                Shopping(player);
            }
        
        }
        
        private void SellShopping(Player player)
        {
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.gold);

            Console.WriteLine("[아이템 목록]");
            for(int i=0; i < player.inven.Count; i++)
            {
                Console.WriteLine($"{player.inven[i].equipMsg}{i + 1}. {player.inven[i].itemName}    | {player.inven[i].optionText}+{player.inven[i].option}    | {player.inven[i].itemInfo}     | {player.inven[i].sellGold} G");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            string input = Console.ReadLine();
            int inputNum = 0;
            inputNum = int.TryParse(input, out inputNum) ? inputNum : -1;

            if (inputNum == 0)
            {
                Console.Clear();
                Shopinfo(player);
            }
            else if (inputNum < 0)  // 이상한 번호를 타이핑 했을때
            {
                Console.Clear();
                Console.WriteLine("다시 입력해주세요");
                SellShopping(player);
            }
            else if (inputNum -1 < player.inven.Count)
            {
                player.inven[inputNum - 1].isBuy = false;
                player.inven[inputNum -1].isEquip = false;
                player.inven[inputNum - 1].equipMsg = "";
                if (player.inven[inputNum - 1].itemType == ItemType.Weapon)
                {
                    player.addAtk -= player.inven[inputNum - 1].option;
                }
                else if (player.inven[inputNum - 1].itemType == ItemType.Armor)
                {
                    player.addDef -= player.inven[inputNum - 1].option;
                }
                player.gold += player.inven[inputNum - 1].sellGold;
                player.inven.RemoveAt(inputNum - 1);
                Console.Clear();
                SellShopping(player);
            }
            else
            {
                Console.Clear();
                SellShopping(player);
            }    


        }
    }
}
