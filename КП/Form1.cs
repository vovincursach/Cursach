using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace КП
{
    public partial class Form1 : Form
    {
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            infoLabel = new ToolStripLabel();

            infoLabel.Text = "Поточні дата и час:";

            dateLabel = new ToolStripLabel();

            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);

            statusStrip1.Items.Add(dateLabel);

            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };

            timer.Tick += timer_Tick;

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();

            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var data = new CarModel
            {
                Name = textBox1.Text,

                Mark = textBox4.Text,

                Color = textBox3.Text
            };

            SQLHandler search = new SQLHandler();

            var results = search.SelectAllCars(data);

            if (results.Count < 1)
            {
                MessageBox.Show(
                    "Товарів не знайдено.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1); 
            }
            else
            {
                textBox7.Text = ((CarModel)results[0]).Mark.ToString();

                textBox8.Text = ((CarModel)results[0]).Name.ToString();

                textBox6.Text = ((CarModel)results[0]).Color.ToString();

                textBox10.Text = ((CarModel)results[0]).Fuel.ToString();

                textBox11.Text = ((CarModel)results[0]).EnginePower.ToString();

                textBox12.Text = ((CarModel)results[0]).EngineVolume.ToString();

                textBox13.Text = ((CarModel)results[0]).TankVolume.ToString();

                textBox5.Text = ((CarModel)results[0]).Price.ToString();

                textBox2.Text = ((CarModel)results[0]).Discount.ToString();

                switch (data.Name)
                {
                    case "Kaen":

                        search.ReadFileFromDatabase("Porsche_Cayenne.jpg");

                        

                        break;

                    case "Q7":

                        search.ReadFileFromDatabase("Audi_Q7.jpg");

                        break;

                    case "X6":

                        search.ReadFileFromDatabase("BMW_X6.jpg");

                        break;

                    case "Kamaro":

                        search.ReadFileFromDatabase("Chevrolet_Camaro.jpg");

                        break;

                    case "Golf":

                        search.ReadFileFromDatabase("Volkswagen_Golf.jpg");

                        break;

                    case "Charger":

                        search.ReadFileFromDatabase("Dodge_Charger.jpg");

                        break;

                    case "Aventador":

                        search.ReadFileFromDatabase("Lamborghini_Aventador.jpg");

                        break;

                    case "Logan XX века":

                        search.ReadFileFromDatabase("Renault_Logan.png");

                        break;

                    case "3000 GT":

                        search.ReadFileFromDatabase("Mitsubishi_3000GT.jpg");

                        break;

                    case "X-Trail":

                        search.ReadFileFromDatabase("Nissan_X-Trail.jpg");

                        break;

                    case "Corolla":

                        search.ReadFileFromDatabase("Toyota_Corolla.jpg");

                        break;
                }

                Image image = Image.FromFile(search.Images[0].FileName);

                pictureBox1.Image = image;
            }
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void TextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }
        
        private void АвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();

            newForm.Show();
        }

        private void ПокупціToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3();

            newForm.Show();
        }

        private void ПродажіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();

            newForm.Show();
        }

        private void ЗавантажитиВБазуДанихToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLHandler save = new SQLHandler();

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Porsche_Cayenne.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Audi_Q7.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\BMW_X6.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Chevrolet_Camaro.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Volkswagen_Golf.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Dodge_Charger.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Lamborghini_Aventador.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Renault_Logan.png");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Mitsubishi_3000GT.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Nissan_X-Trail.jpg");

            save.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\Toyota_Corolla.jpg");

            MessageBox.Show(
                    "Зображення завантажені.",
                    "Повідомлення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
        }
    }
}