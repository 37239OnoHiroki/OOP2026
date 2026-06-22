namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                var sale = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2]),
                };
                sales.Add(sale);
            }
            return sales;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var sale in _score) {
                //すでに店舗名が辞書のキーに登録されているか？
                if (dict.ContainsKey(sale.Name))
                    //すでに店舗名が辞書のキーに登録されている場合
                    dict[sale.Name] += sale.Score;//売り上げを足しこみ
                else
                    //店舗名の登録がまだない場合
                    dict[sale.Name] = sale.Score;//新規に売り上げを登録
            }
            return dict;
        }
    }
}
