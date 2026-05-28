
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(" --- 4.2.1 ---");
            Exercise1();
            Console.WriteLine("\n --- 4.2.2 ---");
            Exercise2();
            Console.WriteLine("\n --- 4.2.3 ---");
            Exercise3();
        }

        private static void Exercise1() {
            //if-else文を使用
            var line = Console.ReadLine();
            if (int.TryParse(line, out int num)) {

                if (num < 0) {
                    Console.WriteLine(num);
                } else if (num < 100) {
                    Console.WriteLine(num * 2);
                } else if (num < 500) {
                    Console.WriteLine(num * 3);
                } else {
                    Console.WriteLine(num);
                }
            } else Console.WriteLine("入力値に誤りがあります");
        }

        private static void Exercise2() {
            //switch文を使用
            var line = Console.ReadLine();
            if (int.TryParse(line, out int num)) {
                switch (num) {
                    case < 0:
                        Console.WriteLine(num);
                        break;
                    case < 100:
                        Console.WriteLine(num * 2);
                        break;
                    case < 500:
                        Console.WriteLine(num * 3);
                        break;
                    case >= 500:
                        Console.WriteLine(num);
                        break;

                }

            } else Console.WriteLine("入力値に誤りがあります");
        }

        private static void Exercise3() {
            //switch式を使用
            var number = Console.ReadLine();
            if (int.TryParse(number, out int result)) {
                var text = result switch {
                    < 0 => Console.WriteLine(result),
                    < 100 =>Console.WriteLine(result*2),
                    < 500 =>Console.WriteLine(result*3),
                    _=> Console.WriteLine(result)

                };
            }else Console.WriteLine("入力値に誤りがあります");
        }
    }
}
