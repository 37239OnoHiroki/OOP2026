namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();
        static void Main(string[] args) {
            string? pref, prefCaptalLocation;
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'");

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
                prefOfficeDict.Add(pref, prefCaptalLocation);
            }
            int loop = 0;
            while (loop ==0) {
                Console.WriteLine("****メニュー****");
                Console.WriteLine("1:一覧表示");
                Console.WriteLine("2:検索");
                Console.WriteLine("9:終了");

                Console.Write(">");

                var select = Console.ReadLine();
                if (int.TryParse(select, out int num)) {
                    switch (num) {
                        case < 2:
                            Console.WriteLine("1");
                            foreach (var item in prefOfficeDict) {
                                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
                            }
                            loop = 0;
                            continue;
                        case < 3:
                            //Console.WriteLine("2");
                            Console.Write("都道府県：");
                            pref = Console.ReadLine();
                            if (prefOfficeDict.ContainsKey(pref)) {
                                var result = prefOfficeDict[pref];
                                Console.WriteLine(result);
                            }
                            loop = 0;
                            continue;
                        case < 10:
                            //Console.WriteLine("9")
                            loop = 1;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
