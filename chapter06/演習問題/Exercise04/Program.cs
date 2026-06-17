using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var cnt = 0;
            var category1 = line.Split(';');
            foreach (var array in category1) {
                var category2 =array.Split('=');
                Console.WriteLine($"{ToJapanese(category2[0])}:{category2[1]}");
            }
            
        }
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数keyは、正しい値ではありません"
            };
            //古い書き方
            //switch (key) {
            //    case "Novelist":　
            //        return "作家";
            //    case "BestWork":
            //        return "代表作";
            //    case "Born":
            //        return "誕生年";
            //    default:
            //        return "引数keyは、正しい値ではありません";
            //}
        }
    }
}
