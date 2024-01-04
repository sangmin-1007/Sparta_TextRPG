namespace Sprata_TextRPG
{
    internal class Program
    {
        static bool run = true;
        static Item item1 = new Item("무쇠갑옷", 5, "방어력", "무쇠로 만들어져 튼튼한 갑옷입니다.");

        static void Main(string[] args)
        {

            Player player = new Player();
            player.CreatePlayer(1, "김상민", "전사", 10, 5, 100, 1500);
            player.AddInven(item1);

            while (run)
            {
                StartScene(player);
            }
        }

        static void StartScene(Player player)
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
                    // 플레이어 정보
                    player.Info();
                    break;
                case "2":
                    // 인벤토리
                    player.Inven();
                    break;
                case "3":
                    // 상점
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
    }
}