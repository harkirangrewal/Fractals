using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals_Sierpinski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Generate_Sierpinski(int n, Graphics g, Point p1, Point p2, Point p3)
        {
            if (n == 0)
                return;
            else
            {
                Point[] triangle = new Point[3];
                Point m1, m2, m3;
                m1 = new Point();
                m2 = new Point();
                m3 = new Point();

                triangle[0] = p1;
                triangle[1] = p2;
                triangle[2] = p3;

                Pen myPen = new Pen(Color.Red, 1);
                g.DrawPolygon(myPen, triangle);

                // midpoint of linesegment p1p2
                m1.X = (p1.X + p2.X) / 2;
                m1.Y = (p1.Y + p2.Y) / 2;

                // midpoint of linesegment p1p3
                m2.X = (p1.X + p3.X) / 2;
                m2.Y = (p1.Y + p3.Y) / 2;

                // midpoint of linesegment p2p3
                m3.X = (p2.X + p3.X) / 2;
                m3.Y = (p2.Y + p3.Y) / 2;

                Generate_Sierpinski(n - 1, g, p1, m1, m2);
                Generate_Sierpinski(n - 1, g, m1, p2, m3);
                Generate_Sierpinski(n - 1, g, m2, m3, p3);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int n; Point p1, p2, p3;
            n = Convert.ToInt32(txtLevel.Text);

            p1 = new Point();
            p2 = new Point(); p3 = new Point();

            p1.X = 300; p1.Y = 1; p2.X = 1; p2.Y = 600;
            p3.X = 600; p3.Y = 600;

            Graphics g = Graphics.FromHwnd(pictureBox1.Handle); g.Clear(Color.White);
            Generate_Sierpinski(n, g, p1, p2, p3);
        }
    }
}
