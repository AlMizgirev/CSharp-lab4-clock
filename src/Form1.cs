using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Width = 700;
            Height = 700;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Silver, 2);
            Brush brush = new SolidBrush(Color.Indigo);
            Graphics g = e.Graphics;
            GraphicsState gs;
            g.TranslateTransform(Width / 2, Height / 2);
            g.ScaleTransform(500 / 200, 500 / 200);
            g.DrawEllipse(cir_pen, -120, -120, 240, 240);
            g.DrawRectangle(new Pen(Color.LightGray), 60, -8, 20, 15);
            g.DrawString(Convert.ToString(dt.Day), new Font("Arial", 8F), new SolidBrush(Color.Black), 62, -6);
            gs = g.Save();
            for(int i = 0; i < 12; i++)
            {
                g.RotateTransform(30 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.DimGray), 6), 0, -120, 0, -100);
                
                g.Restore(gs);
                gs = g.Save();
            }
            for (int i = 0; i < 60; i++)
            {
                g.RotateTransform(6 * i);
                g.DrawLine(new Pen(new SolidBrush(Color.DimGray), 3), 0, -120, 0, -116);

                g.Restore(gs);
                gs = g.Save();
            }
            gs = g.Save();
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(new Pen(new SolidBrush(Color.Goldenrod), 3), 0, 0, 0, -85);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(6 * (float)dt.Second);
            g.DrawLine(new Pen(new SolidBrush(Color.Gold), 2), 0, 0, 0, -110);
            g.Restore(gs);
            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60 + (float)dt.Second / 3600));
            g.DrawLine(new Pen(new SolidBrush(Color.DarkGoldenrod), 4), 0, 0, 0, -55);
            g.Restore(gs);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
