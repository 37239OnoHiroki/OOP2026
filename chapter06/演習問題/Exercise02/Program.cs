namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("整数文字列:");
            var number = Console.ReadLine();
            if (int.TryParse(number, out int num)) {
                Console.WriteLine($"{num}#,0");
            } else {
                Console.WriteLine("整数ではありません");
            }
        }
    }
}
