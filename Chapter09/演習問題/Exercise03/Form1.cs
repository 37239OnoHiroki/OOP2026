using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

namespace Exercise03 {
    public partial class Form1 : Form {
        Stopwatch sw = new Stopwatch();

        public Form1() {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e) {
            sw.Start();
            timer1.Start();
        }

        private void btStop_Click(object sender, EventArgs e) {
            sw.Stop();
            timer1.Stop();
            lbTimeDisp.Text = $"{sw.Elapsed}•b";
        }

        private void timer1_Tick(object sender, EventArgs e) {
            lbTimeDisp.Text = $"{sw.Elapsed}•b";
        }

        private void btReset_Click(object sender, EventArgs e) {
            sw.Reset();
            lbTimeDisp.Text = $"{sw.Elapsed}";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            
        }
    }
}

//internal class TimeWatch {
//    private DateTime _time;


//    public void Start() {
//        _time= DateTime.Now;
        
//    }

//    public TimeSpan Stop() {
//        return DateTime.Now-_time;
//    }
//}
