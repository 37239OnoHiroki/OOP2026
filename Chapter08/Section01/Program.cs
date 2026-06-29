namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();
        static void Main(string[] args) {
            string? pref, prefCaptalLocation;
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break; //無限ループを抜けるCtrl + 'Z'
                //②県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                if (prefCaptalLocation == null) break;
                //③県庁所在地登録処理
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか？(y/n)");
                    var yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y") {
                        prefOfficeDict[pref] = prefCaptalLocation;
                    }
                    continue;
                } else {
                    prefOfficeDict.Add(pref, prefCaptalLocation);
                }

            }
            int loop = 0;
            while (loop == 0) {

                switch (menuDisp()) {
                    case 1:

                        allDisp(prefOfficeDict);
                        continue;
                    case 2:

                        searchprefCaptalLocation(prefOfficeDict);
                        continue;
                    case 9:
                        loop = 1;
                        break;
                    default:
                        break;
                }
            }
        }





        private static int menuDisp() {
            Console.WriteLine("****メニュー****");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");
            Console.Write(">");

            var select = int.TryParse(Console.ReadLine(), out int num);

            return num;
        }


        public static void allDisp(Dictionary<string, string> prefOfficeDict) {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }

        public static void searchprefCaptalLocation(Dictionary<string, string> prefOfficeDict) {
            Console.Write("都道府県：");
            var searchpref = Console.ReadLine();
            if (prefOfficeDict.ContainsKey(searchpref)) {
                var result = prefOfficeDict[searchpref];
                Console.WriteLine(result);
            }
        }

    }
}
