using System;
using System.Windows.Forms;

namespace КП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            FormBorderStyle = FormBorderStyle.None;

            timer1.Interval = 3000;

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

                if (progressBar1.Value == 20)
                    label1.Text = "Правильно оформляем таблицы ...";

                if(progressBar1.Value == 60)
                    label1.Text = "Готовим кампутер к работе ...";

                if (progressBar1.Value == 80)
                    label1.Text = "Скачиваем курсовую с ГДЗ.online ...";

                if (progressBar1.Value == 100)
                    label1.Text = "Готово!!!";
            }
        }
    }
}
