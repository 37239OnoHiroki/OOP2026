
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            #region　各演習の呼び出し（ドライバ）

            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);
            #endregion
        }

        private static void Exercise1(List<int> numbers) {
            Console.WriteLine("---3.1.1----");
            var exis = numbers.Exists(num => num %8 ==0 || num %9 ==0);
            if (exis == true) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }
        }

        private static void Exercise2(List<int> numbers) {
            Console.WriteLine("---3.1.2----");
            numbers.ForEach(num => Console.WriteLine( num /2.0));
        }

        private static void Exercise3(List<int> numbers) {
            Console.WriteLine("---3.1.3----");

            numbers.Where(n => n > 50).ToList().ForEach(n => Console.WriteLine(n));

            //var query = numbers.Where(s => s >= 50).ToList();
            //foreach (var item in query) {
            //    Console.WriteLine(item);
            //}
        }

        private static void Exercise4(List<int> numbers) {
            Console.WriteLine("---3.1.4----");
            var query = numbers.Select(s => s *2).ToList();
            foreach (int num in query) {
                Console.WriteLine(num);
            }

        }
    }
}
