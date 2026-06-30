
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);
            Console.WriteLine();
        }

        private static void Exercise1(string text) {
            var alphabetCounter = new Dictionary<char, int>();
            foreach (var alphabet in text.ToUpper()) {
                if ('A' <= alphabet && alphabet <= 'Z') {
                    if (alphabetCounter.ContainsKey(alphabet)) {
                        alphabetCounter[alphabet]++;
                    } else {
                        alphabetCounter[alphabet] = 1;
                    }
                }
            }
            foreach (var item in alphabetCounter.OrderBy(x =>x.Key)) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }

        private static void Exercise2(string text) {
            var alphabetCounter = new SortedDictionary<char, int>();
            foreach (var alphabet in text.ToUpper()) {
                if ('A' <= alphabet && alphabet <= 'Z') {
                    if (alphabetCounter.ContainsKey(alphabet)) {
                        alphabetCounter[alphabet]++;
                    } else {
                        alphabetCounter[alphabet] = 1;
                    }
                }
            }

            foreach (var item in alphabetCounter) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }
    }
}
