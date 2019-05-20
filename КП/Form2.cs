using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            var data = new CarModel { 
            Name = textBox1.Text
            //
            // для того, чтобы убрать парсинг строки в обьект нужно добавить 4 текстбокса
            //
            };

            SQLHandler y = new SQLHandler();

            y.SelectAll();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var result = sender.ToString().Replace(" ", "").Replace(",", " ");
            //SQLHandler.Insert(result);
            Trace.WriteLine(result);
        }
    }
}
