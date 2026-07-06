namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) {
            tbOutput.Text = (nudNum1.Value + nudNum2.Value).ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();

        }
    }
}
