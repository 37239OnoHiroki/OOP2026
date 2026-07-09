using System.Globalization;
using System.Runtime.Serialization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value.Date; //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today; //ç°ì˙ÇÃì˙ït

            //var age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}
            tbOut.Text = $"{GetAge(birth, today)}çŒ";

            TimeSpan ts = today.Date - birth.Date;
            tbOut2.Text = $"ê∂Ç‹ÇÍÇƒÇ©ÇÁ{ts.Days}ì˙ñ⁄Ç≈Ç∑ÅB";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbOut3.Text =$"ê∂Ç‹ÇÍÇΩ{birth.Month}åé{birth.Day}ì˙ÇÕëÊ{NthWeek(birth)}èTÇÃ{culture.DateTimeFormat.GetDayName(birth.DayOfWeek)}Ç≈Ç∑";

            //ç°îNÇÃíaê∂ì˙ÇçÏê¨Ç∑ÇÈ
            DateTime thisYearBirthday = new DateTime(today.Year, birth.Month, birth.Day);
            //Ç∑Ç≈Ç…íaê∂ì˙Ç™âﬂÇ¨ÇΩÇ©ÅH
            if(thisYearBirthday < today) {
                //ñ¢óàÇÃíaê∂ì˙ÇçÏê¨Ç∑ÇÈ
                thisYearBirthday = thisYearBirthday.AddYears(1);
            }

            var span = thisYearBirthday - today;

            if (span.Days ==0) {
                tbOut4.Text = "íaê∂ì˙ÇÕç°ì˙Ç≈Ç∑";
            } else {
                tbOut4.Text = $"íaê∂ì˙Ç‹Ç≈Ç†Ç∆{span.Days}ì˙Ç≈Ç∑ÅB";
            }
            
        }
        //îNóÓÇãÅÇﬂÇÈÉÅÉ\ÉbÉh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        //éwíËÇµÇΩì˙Ç™ëÊâΩèTñ⁄Ç©í≤Ç◊ÇÈ
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }
    }
}
