namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            tbOUt1.Text =dateTime.ToString("yyyy/mm/dd HH:mm");
        }
    }
}
