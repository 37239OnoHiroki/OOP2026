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
            DateTime birth = dtpBirth.Value; //¶‚Ü‚ê‚½“ú•t
            DateTime today = DateTime.Today; //¡“ú‚Ì“ú•t

            //var age = today.Year - birth.Year;
            //if(today < birth.AddYears(age)) {
            //    age--;
            //}
            tbOut.Text = $"{GetAge(birth, today)}Î";

            TimeSpan ts = today.Date - birth.Date;
            tbOut2.Text = $"¶‚Ü‚ê‚Ä‚©‚ç{ts.Days}“ú–Ú‚Å‚·B";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbOut3.Text =$"¶‚Ü‚ê‚½{birth.Month}Œ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{culture.DateTimeFormat.GetDayName(birth.DayOfWeek)}‚Å‚·";


            DateTime nextYear = birth.AddYears((today.Year - birth.Year) + 1);

            if (today.Month== birth.Month && today.Day == birth.Day) {
                tbOut4.Text = $"¡“ú‚ª’a¶“ú";
            } else {
                if (today.Date > birth.AddYears(today.Year - birth.Year).Date) {
                    tbOut4.Text = $"—ˆ”N‚Ì’a¶“ú‚Ü‚Å‚ ‚Æ{365+((nextYear.Date-today.Date).TotalDays-365)}“ú";
                } else {
                    tbOut4.Text = $"’a¶“ú‚Ü‚Å‚ ‚Æ{365-((today.Date-(birth.AddYears(today.Year-birth.Year)).Date).Days-(-365))}“ú";
                }
            }





            //if (today.Month>birth.Month) {
            //    tbOut4.Text = $"—ˆ”N‚Ì’a¶“ú‚Ü‚Å‚ ‚Æ{(birth.AddYears((today.Year-birth.Year)+1).Date- today.Date).Days}";
            //} else {
            //    if(today.Month == birth.Month&& today.Day == birth.Day) {
            //        tbOut4.Text = $"¡“ú‚ª’a¶“ú";
            //    } else {
            //        tbOut4.Text = "";
            //    }
            //}

        }
        //”N—î‚ğ‹‚ß‚éƒƒ\ƒbƒh
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        //w’è‚µ‚½“ú‚ª‘æ‰½T–Ú‚©’²‚×‚é
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }
    }
}
