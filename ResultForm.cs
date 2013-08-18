using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hierarchy_of_Needs
{
    public partial class ResultForm : Form
    {
        public ResultForm(MainForm parent, Needs needs)
        {
            InitializeComponent();
            this.parent = parent;
        }
        MainForm parent;

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackgroundImage = bmp;
        }
    }
}
