using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private double x = 0.0;
        private List<string> keying = new List<string>();
        private double ex, ey = 0.0;

        Random randomizer = new Random();
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer2.Enabled = true;
            label1.Text = score.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this.Text = ProductName;// ピクチャボックスの設定
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // 縦横比を変えずに引き延ばす
            //pictureBox1.Image = Properties.Resources.丹羽安二郎;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, (int)ex, (int)ey, 10, 10);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // 縦横比を変えずに引き延ばす
            pictureBox1.Image = Properties.Resources.丹羽安二郎; //e.Graphics.FillRectangle(Brushes.Black, (int)x, 300, 50, 50);

            if ((ex + 10.0 > x && ex + 10.0 < x + 50) || (ex > x && ex < x + 50))
            {
                if ((ey + 10.0 > 300 && ey + 10.0 < 300 + 50) || (ey > 300 && ey < 300 + 50))
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keying.Contains("Left") && x > 0)
                x -= 2.0;
            if (keying.Contains("Right") && x + 50 < pictureBox1.Width)
                x += 2.0;
            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!keying.Contains(e.KeyCode.ToString()))
                keying.Add(e.KeyCode.ToString());

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ey >= pictureBox1.Height)
                ey = 0.0;
            if (ey == 0.0)
                ex = randomizer.Next(pictureBox1.Width);
            else
                ex += randomizer.Next(5) - 2;
            ey += 2.0;
            pictureBox1.Invalidate();
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keying.Remove(e.KeyCode.ToString());
        }
    }
}
