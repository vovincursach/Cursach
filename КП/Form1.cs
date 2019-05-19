using System;
using System.Drawing;
using System.Windows.Forms;

namespace КП
{
    public partial class Form1 : Form
    {
        Timer tmr = new Timer() { Interval = 6000 };
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500; // 500 миллисекунд
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            if (progressBar1.Value == 500)
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}
