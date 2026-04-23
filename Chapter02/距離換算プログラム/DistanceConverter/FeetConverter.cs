using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    public static　class FeetConverter//static 静的クラス
    {
        //メートルからフィートを求める
        public static double FromMeter(int feet)
        {
            return feet / 0.3048;
        }
        //フィートからメートルを求める
        public static double ToMeret(int feet)
        {
            return feet * 0.3048;
        }
    }
}
