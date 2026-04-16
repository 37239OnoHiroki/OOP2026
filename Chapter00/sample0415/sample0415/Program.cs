namespace sample0415
{
    internal class Program
    {

        static void Main(string[] args)
        {


            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)  //入力
            {
                Console.Write("[" + i + "] " + "入力値：");
                array[i] = int.Parse(Console.ReadLine());

            }


            for (int i = 0; i < array.Length; i++)　//要素の中身を順に出力
            {
                Console.WriteLine();
                Console.Write("[" + i + "] ");
                astOut(array[i]);

            }

            //Console.WriteLine();

            //int total = 0;
            //for (int i = 0; i < array.Length; i++)   //合計計算
            //{
            //    total += array[i];
            //}



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("合計" + array.Where(n=>n%2==0).Sum());  //合計出力

        }

        //array.Where(n=>n%2==0).Sum()偶数だけ合計

        static void astOut(int num)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write("*");
            }
        }
    }
}
