using System;
using System.Windows.Forms;

namespace КП
{
    public partial class LoadingScreen : Form
    {
        private bool IsJoke = false;
        public LoadingScreen()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            FormBorderStyle = FormBorderStyle.None;

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

                if (progressBar1.Value == 20)
                    label1.Text = "Нормалізуємо таблиці...";

                if (progressBar1.Value == 40 && IsJoke)
                    label1.Text = "Зачекайте будь-ласка";

                if (progressBar1.Value == 60)
                    label1.Text = "Підготовка програми до роботи...";

                if (progressBar1.Value == 60 && IsJoke)
                    label1.Text = "Підключення до бази даних";

                if (progressBar1.Value == 80)
                    label1.Text = "Завантажуємо курсову с Github ...";

                if (progressBar1.Value == 80 && IsJoke)
                    label1.Text = "Будь-ласка, не йдіть!!! зара запрацює";

                if (progressBar1.Value == 100 && !IsJoke)
                {
                    label1.Text = "Готово!!! (Шуткую, нє)";
                    progressBar1.Value = 20;
                    IsJoke = true;
                }
            }
        }
    }
}
