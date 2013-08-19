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
            this.needs = needs;
        }
        MainForm parent;
        Needs needs;

        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
        }

        bool isDrawed = false;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawed)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Graphics gr = Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int[] needsArr = { needs.material, needs.safety, needs.connections, needs.respect, needs.realisation };
                for (int M = 0; M < 5; ++M)
                {
                    int N = needsArr[M];
                    DrawBar(gr, N, M);
                }

                pictureBox1.Image = bmp;

                isDrawed = true;
            }
        }

        private static void DrawBar(Graphics gr, int N, int M)
        {
            SolidBrush brush;
            {
                Color color;
                switch (M)
                {
                    case 0:
                        color = Color.Blue;
                        break;
                    case 1:
                        color = Color.Red;
                        break;
                    case 2:
                        color = Color.Green;
                        break;
                    case 3:
                        color = Color.Yellow;
                        break;
                    case 4:
                        color = Color.Violet;
                        break;
                    default:
                        throw new Exception();
                }
                brush = new SolidBrush(Color.FromArgb(240, color));
            }

            int length = N * 3;
            int x = 26 + M * 58, y = 126 - length;
            gr.FillRectangle(brush, x, y, 10, length);
            gr.DrawRectangle(new Pen(Color.White), x, y, 10, length);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
