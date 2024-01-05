namespace Sprata_TextRPG
{
    internal class Program
    {
        static bool run = true;
        static Item item1 = new Item("수련자 갑옷", 5, ItemType.Armor, "수련에 도움을 주는 갑옷입니다.",1000);
        static Item item2 = new Item("무쇠갑옷", 9, ItemType.Armor, "무쇠로 만들어진 튼튼한 갑옷입니다.", 1500);
        static Item item3 = new Item("스파르타의 갑옷", 15, ItemType.Armor, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500);
        static Item item4 = new Item("낡은 검", 2, ItemType.Weapon, "쉽게 볼 수 있는 낡은 검 입니다.", 600);
        static Item item5 = new Item("청동 도끼", 5, ItemType.Weapon, "어디선가 사용됐던거 같은 도끼입니다.", 1500);
        static Item item6 = new Item("스파르타의 창", 7, ItemType.Weapon, "스파르타의 전사들이 사용했다는 전설의 창입니다.",3500);
        static Item item7 = new Item("상민이가 받는 고통", 9999, ItemType.Weapon, "과제가 힘들어 죽으려고하는 상민이의 고통이 서린 검", 999999);
        static void Main(string[] args)
        {

            Player player = new Player();
            player.CreatePlayer(1, "김상민", "전사", 10, 5, 100, 10000);
            Shop shop = new Shop();
            shop.AddShopItem(item1);
            shop.AddShopItem(item2);
            shop.AddShopItem(item3);
            shop.AddShopItem(item4);
            shop.AddShopItem(item5);
            shop.AddShopItem(item6);
            shop.AddShopItem(item7);

            while (run)
            {
                StartScene(player,shop);
            }
        }

        static void StartScene(Player player ,Shop shop)
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
                    Console.Clear();
                    player.Info();
                    break;
                case "2":
                    // 인벤토리
                    Console.Clear();
                    player.Inven();
                    break;
                case "3":
                    // 상점
                    Console.Clear();
                    shop.Shopinfo(player);
                    break;
                case "0":
                    run = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine(" ");
                    Console.WriteLine("잘못된 입력입니다. ");
                    Console.WriteLine(" ");
                    break;
            }
            
        }
    }
}