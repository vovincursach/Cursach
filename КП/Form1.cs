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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var result = sender.ToString().Replace(" ", "").Replace(",", " ");
            //SQLHandler.Insert(result);
            Trace.WriteLine(result);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SQLHandler.Insert(textBox1.Text);
        }
    }
}
