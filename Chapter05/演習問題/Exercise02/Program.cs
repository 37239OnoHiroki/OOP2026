using Exercise01;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);


            Console.WriteLine("\n5.2.3");
            FindFirst21C(ymCollection);

            Console.WriteLine("\n5.2.4");
            Exercise4(ymCollection);


            Console.WriteLine("\n5.2.5");
            Exercise5(ymCollection);
        }


        private static void Exercise2(YearMonth[] ymCollection) {
            foreach (var item in ymCollection) {
                Console.WriteLine(item);
            }
        }

        //5.2.3
        private static YearMonth? FindFirst21C(YearMonth[] ymCollection) {
            foreach(var item in ymCollection) {
                if (item.Is21Century.Equals (true)) {
                    Console.WriteLine(item);
                    break;
                } 
            }
            return null;
        }

        private static void Exercise4(YearMonth[] ymCollection) {
            //if(FindFirst21C  null) {
            //    Console.WriteLine("２１世紀のデータはありません");
            //}
        }

        private static void Exercise5(YearMonth[] ymCollection) {
            
        }
    }
}
