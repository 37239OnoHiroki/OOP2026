using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year ,int month) {
            year = Year;
            month = Month;
        }
        //5.1.2(p116参照）
        //設定されている西暦が21世紀か判断する
        //Yearが2001～2100の間ならtrue
        public bool Is21Century => 2001<=Year&&Year <= 2100;

        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(Year+1, 1);
            } else {
                return new YearMonth(Year, Month + 1);
            }
        }

        public override string ToString() {
            return $"{Year}年{Month}月";
        }
    }
}
