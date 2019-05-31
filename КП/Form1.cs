using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace КП
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var data = new CarModel
            {
                Name = textBox1.Text,
                Color = textBox4.Text,
                Mark = textBox3.Text,
                Price = Convert.ToDecimal(textBox2.Text),
                Fuel = textBox9.Text
            };
            
            SQLHandler search = new SQLHandler();

            search.SaveFileToDatabase(@"E:\CP\Cursach\КП\Images\1.jpg");

            var results = search.SelectAllCars(data);

            if (results.Count < 1)
            {
                MessageBox.Show(
                    "Товарів не знайдено.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                textBox8.Text = ((CarModel)results[0]).Name.ToString();

                textBox7.Text = ((CarModel)results[0]).Price.ToString();

                textBox6.Text = ((CarModel)results[0]).Color.ToString();

                textBox5.Text = ((CarModel)results[0]).Mark.ToString();

                textBox10.Text = ((CarModel)results[0]).Fuel.ToString();

                textBox11.Text = ((CarModel)results[0]).EnginePower.ToString();

                textBox12.Text = ((CarModel)results[0]).EngineVolume.ToString();

                textBox13.Text = ((CarModel)results[0]).TankVolume.ToString();

            }

            search.ReadFileFromDatabase("1");

            Image image = Image.FromFile(search.Images[0].FileName);

            pictureBox1.Image = image;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var result = sender.ToString().Replace(" ", "").Replace(",", " ");
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void TextBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ПереглянутиДаніToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

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

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.Text = "";
        }
    }
}
