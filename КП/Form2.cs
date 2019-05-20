using System;
using System.Windows.Forms;

namespace КП
{
    public partial class Form2 : Form
    {
        public Form2()
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
            Color = textBox2.Text,
            Mark = textBox3.Text,
            Price = Convert.ToDecimal(textBox4.Text)
            };

            SQLHandler search = new SQLHandler();

            var results = search.SelectAll(data);
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
    }
}
