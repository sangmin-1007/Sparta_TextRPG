using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sprata_TextRPG
{


    internal class Player
    {
        public int level;
        public string name;
        public string classType;
        public int atk;
        public int def;
        public int hp;
        public int gold;

        public int addAtk;
        public string addAtkTxt;
        public int addDef;
        public string addDefTxt;

        
        List<Item> inven = new List<Item>();


        public void CreatePlayer(int _level,string _name,  string _classType, int _atk, int _def, int _hp, int _gold) // 플레이어 생성자.
        {
            level = _level;
            name = _name;
            classType = _classType;
            atk = _atk;
            def = _def;
            hp = _hp;
            gold = _gold;
        }

        public void Info() // 플레이어 정보
        {
            string input = "1";

            while(input != "0")
            {
                Console.WriteLine($"{name}  ({classType})");
                if(addAtk == 0)
                {
                    Console.WriteLine($"공격력 : {atk}");
                }
                else
                {
                    addAtkTxt = "(+" + addAtk + ")";
                    Console.WriteLine($"공격력 : {atk} " + addAtkTxt);
                }
                
                if(addDef == 0)
                {
                    Console.WriteLine($"방어력 : {def}");
                }
                else
                {
                    addDefTxt = "(+" + addDef + ")"; 
                    Console.WriteLine($"방어력 : {def} " + addDefTxt);
                }
                
                Console.WriteLine($"체력 : {hp}");
                Console.WriteLine($"Gold : {gold} G");

                Console.WriteLine();
                Console.WriteLine("0.나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                input = Console.ReadLine();

                if(input !=  "0")
                {
                    Console.WriteLine("다시 입력해주세요");
                }

            }
            Console.Clear();
        }

        public void Inven()
        {
            string input = null;

            Console.WriteLine("[아이템 목록]");
            if(inven.Count > 0)
            {
                for (int i = 0; i < inven.Count; i++)
                {
                    Console.WriteLine($"{inven[i].equipMsg}{i + 1}. {inven[i].itemName}    | {inven[i].optionText}+{inven[i].option}    | {inven[i].itemInfo}");
                }
            }
                
            
           

            Console.WriteLine();
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("2. 나가기");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    //장착관리
                    Console.Clear();
                    EquipManager();
                    break;
                case "2":
                    Console.Clear();
                    break;
                default:
                    Inven();
                    break;
            }

        }

        public void AddInven(Item item)
        {
            inven.Add(item);
        } // 인벤에 아이템 추가.



        public void EquipManager() // 장착관리
        {
            string input;
            bool run = true;

            Console.WriteLine("[아이템 목록]");
            if (inven.Count > 0)
            {
                for (int i = 0; i < inven.Count; i++)
                {
                    Console.WriteLine($"{inven[i].equipMsg}{i + 1}. {inven[i].itemName}    | {inven[i].optionText}+{inven[i].option}    | {inven[i].itemInfo}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            input = Console.ReadLine();
            int inputNum = 0;
            inputNum = int.TryParse(input, out inputNum) ? inputNum : -1;
            

            if(inputNum == 0)
            {
                Console.Clear();
                Inven();
                
            }
            else if(inputNum -1 > inven.Count || inputNum-1 < 0)
            {
                Console.Clear();
                EquipManager();
            }
            else
            {
                if (inven[inputNum - 1].isEquip == false)
                {
                    inven[inputNum - 1].isEquip = true;
                    inven[inputNum - 1].equipMsg = "[E] ";
                    if (inven[inputNum - 1].itemType == ItemType.Weapon)
                    {
                        addAtk += inven[inputNum - 1].option;
                        addAtkTxt = " ( + " + addAtk + ")";
                    }
                    else if (inven[inputNum - 1].itemType == ItemType.Armor)
                    {
                        addDef += inven[inputNum - 1].option;
                        addDefTxt += " (+" + addDef + ")";
                    }
                    Console.Clear();
                    EquipManager();

                }
                else
                {
                    inven[inputNum-1].isEquip = false;
                    inven[inputNum - 1].equipMsg = "";
                    if (inven[inputNum - 1].itemType == ItemType.Weapon)
                    {
                        addAtk -= inven[inputNum-1].option;
                        //addAtkTxt = " ( + " + addAtk + ")";
                       
                    }
                    else if (inven[inputNum-1].itemType == ItemType.Armor)
                    {
                        addDef -= inven[inputNum-1].option;
                        //addDefTxt += " (+" + addDef + ")";
                    }
                    Console.Clear();
                    EquipManager();
                }

            }

        }
    }
}
