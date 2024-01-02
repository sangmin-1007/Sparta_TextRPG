namespace Sprata_TextRPG
{
    internal class Program
    {
        static bool run = true;

        struct Player 
        {
            public int level;
            public string name;
            public string classType;
            public int atk;
            public int def;
            public int hp;
            public int gold;
        }


        static void Main(string[] args)
        {
            Player player;
            CreatePlayer(out player);

            while (run)
            {
                StartScene(ref player);
            }
        }

        static void StartScene(ref Player player)
        {
            Console.WriteLine("스파르타 마을에 오신것을 환영합니다");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("0. 종료");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Info(ref player);
                    break;
                case "2":
                    //
                    break;
                case "3":
                    break;
                case "0":
                    run = false;
                    break;
                default:
                    Console.WriteLine(" ");
                    Console.WriteLine("잘못된 입력입니다. ");
                    Console.WriteLine(" ");
                    break;


            }
        }

        static void Info(ref Player player)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine($"Lv . {player.level}");
                Console.WriteLine($"{player.name} ({player.classType})");
                Console.WriteLine($"공격력 : {player.atk}");
                Console.WriteLine($"방어력 : {player.def}");
                Console.WriteLine($"체 력 : {player.hp}");
                Console.WriteLine($"Gold : {player.gold} G");
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.Write(">>");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        StartScene(ref player);
                        run = false;
                        break;
                    default:
                        Console.WriteLine("잘못 입력했습니다.");
                        break;
                }
            }


        }

        static void CreatePlayer(out Player player)
        {
            player.level = 1;
            player.name = "김상민";
            player.classType = "전사";
            player.atk = 10;
            player.def = 5;
            player.hp = 100;
            player.gold = 1500;
        }
    }
}