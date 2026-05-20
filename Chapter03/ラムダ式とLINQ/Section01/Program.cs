namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> {//citiesコレクション
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            //var exists = cities.Exists (s => s[0] == 'B');
            //Console.WriteLine(exists);

            //var name = cities.Find(s => s.Length == 6);
            //Console.WriteLine(name);

            ///int index = cities.FindIndex(s => s == "Berlin");
            //Console.WriteLine(index);

            //cities.ForEach(s => Console.WriteLine(s));

            //cities.ForEach(Console.WriteLine);

            //var exist = cities.FindAll(s => s[0] == 'B');
            //exist.ForEach(s => Console.WriteLine(s));




            //以下の条件を満たすものが存在しているか調べる
            //大文字が6文字以上
            //oを含む
            //最後がｎ
            var exis = cities.Exists(s => 6 <=s.Length && s.Contains('o') && s.EndsWith('n'));
            Console.WriteLine(exis);
        }
    }
}
