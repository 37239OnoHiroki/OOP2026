using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            tbOut1.Text = dateTime.ToString("yyyy/MM/dd HH:mm");
        }

        private void tbButton2_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            tbOut2.Text = dateTime.ToString("yyyy”NMMŒŽdd“ú HHŽžmm•ªss•b");
        }


        private void tbButton3_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(dateTime);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            tbOut3.Text = $"{eraName} {era}”N {dateTime.ToString("MŒŽ d“ú")} ({dayOfWeek})";
        }
    }
}
