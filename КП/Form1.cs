using System;
using System.Drawing;
using System.Windows.Forms;

namespace КП
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if(progressBar1.Value == 100)
            {
                this.Close();
            }
            else
            {
                progressBar1.Value += 10;
            }
        }
    }
}
