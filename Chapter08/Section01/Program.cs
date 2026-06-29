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

                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか？(y/n)");
                    if (Console.ReadLine() == "N") continue;
                }

                //③県庁所在地登録処理
                prefOfficeDict[pref] = prefCaptalLocation;

                Console.WriteLine();//改行
            }

            Boolean endFlag = false;//終了フラグ
            while (!endFlag) {
                switch (menuDisp()) {
                    case 1://一覧出力処理
                        allDisp();
                        break;
                    case 2:
                        searchprefCaptalLocation();
                        break;

                    default:
                        endFlag = true;
                        return;
                }
            }
        }





        private static int menuDisp() {
            Console.WriteLine("****メニュー****");
            Console.WriteLine("1:一覧表示");
            Console.WriteLine("2:検索");
            Console.WriteLine("9:終了");
            Console.Write(">");

            return int.Parse(Console.ReadLine());
        }


        public static void allDisp() {
            foreach (var p in prefOfficeDict) {
                Console.WriteLine($"{p.Key}の県庁所在地は{p.Value}です。");
            }
        }

        public static void searchprefCaptalLocation() {
            Console.Write("都道府県：");
            var searchPref = Console.ReadLine();
            if (searchPref is null) return;
            //検索した結果を表示
            if (prefOfficeDict.ContainsKey(searchPref)) {
                Console.WriteLine(searchPref + "の県庁所在地は" + prefOfficeDict[searchPref]+"です");
            }
        }

    }
}
