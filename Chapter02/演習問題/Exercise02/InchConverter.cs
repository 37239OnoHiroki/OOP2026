using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {

   public static class InchConverter {

        private static readonly double ratio = 0.0254; //定数

        //メートルからインチを求める
        public static double FromMeter(int feet) {
            return feet / ratio;
        }

        //インチからメートルを求める
        public static double ToMeter(int inch) {
            return inch * ratio;
        }
        
    }
}
