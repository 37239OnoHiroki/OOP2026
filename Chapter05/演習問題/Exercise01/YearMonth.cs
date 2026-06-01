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
        public bool Is21Century { get { return (2001<=Year&&Year <= 2100); } }

        //public YearMonth AddOneMonth(int year ,int month ) {
            
        //}
    }
}
