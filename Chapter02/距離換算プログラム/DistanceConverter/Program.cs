namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom")
            {


                //フィートからメートルへの対応表を出力
                for (int feet = 1; feet <= 10; feet++)
                {
                    double meter = FeetToMeter(feet);
                    Console.WriteLine($"{feet}ft ={meter:0.0000}m");
                }

            }
            else
            {

                //メートル法からフィートへの対応表を出力
                for (int meter = 1; meter <= 10; meter++)
                {
                    double feet = FeetToMeter(meter);
                    Console.WriteLine($"{meter}m ={feet:0.0000}ft");
                }

            }


            static double FeetToMeter(int feet)
            {
                //feet*0.3048
                return feet * 0.3048;
            }

            static double MeterToFeet(int feet)
            {
                return feet / 0.3048;
            }

        }
    }
}
