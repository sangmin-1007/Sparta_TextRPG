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

        
        List<Item> inven = new List<Item>();


        public void CreatePlayer(int _level,string _name,  string _classType, int _atk, int _def, int _hp, int _gold)
        {
            level = _level;
            name = _name;
            classType = _classType;
            atk = _atk;
            def = _def;
            hp = _hp;
            gold = _gold;
        }

        public void Info()
        {
            string input = "1";
         
            while(input != "0")
            {
                Console.WriteLine($"{name}  ({classType})");
                Console.WriteLine($"공격력 : {atk}");
                Console.WriteLine($"방어력 : {def}");
                Console.WriteLine($"체력 : {hp}");
                Console.WriteLine($"Gold : {gold}G");

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

            if(inven.Count > 0)
            {
                for (int i = 0; i < inven.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inven[i].itemName}    | {inven[i].itemType}+{inven[i].option}    | {inven[i].itemInfo}");
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
        }
    }
}
