using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaticScene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Статичний сюжетний малюнок";
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Pen sunPen = new Pen(Color.Orange, 3);
            Pen housePen = new Pen(Color.Brown, 3);
            Pen roofPen = new Pen(Color.DarkRed, 3);
            Pen treePen = new Pen(Color.Green, 3);
            Pen roadPen = new Pen(Color.Gray, 4);
            Pen grassPen = new Pen(Color.Green, 2);

            Brush skyBrush = new SolidBrush(Color.LightSkyBlue);
            Brush grassBrush = new SolidBrush(Color.LightGreen);
            Brush sunBrush = new SolidBrush(Color.Yellow);
            Brush houseBrush = new SolidBrush(Color.Bisque);
            Brush roofBrush = new SolidBrush(Color.IndianRed);
            Brush windowBrush = new SolidBrush(Color.LightBlue);
            Brush treeTrunkBrush = new SolidBrush(Color.SaddleBrown);
            Brush treeLeavesBrush = new SolidBrush(Color.ForestGreen);
            Brush roadBrush = new SolidBrush(Color.DarkGray);

            g.FillRectangle(skyBrush, 0, 0, this.Width, this.Height / 2);
            g.FillRectangle(grassBrush, 0, this.Height / 2, this.Width, this.Height / 2);

            g.FillEllipse(sunBrush, 600, 50, 100, 100);
            g.DrawEllipse(sunPen, 600, 50, 100, 100);

            g.DrawLine(sunPen, 650, 40, 650, 10);
            g.DrawLine(sunPen, 650, 160, 650, 190);
            g.DrawLine(sunPen, 590, 100, 560, 100);
            g.DrawLine(sunPen, 710, 100, 740, 100);
            g.DrawLine(sunPen, 610, 60, 585, 35);
            g.DrawLine(sunPen, 690, 60, 715, 35);
            g.DrawLine(sunPen, 610, 140, 585, 165);
            g.DrawLine(sunPen, 690, 140, 715, 165);

            g.FillRectangle(houseBrush, 250, 250, 200, 150);
            g.DrawRectangle(housePen, 250, 250, 200, 150);

            Point[] roof =
            {
                new Point(230, 250),
                new Point(350, 170),
                new Point(470, 250)
            };
            g.FillPolygon(roofBrush, roof);
            g.DrawPolygon(roofPen, roof);

            g.FillRectangle(Brushes.Sienna, 330, 320, 40, 80);
            g.DrawRectangle(housePen, 330, 320, 40, 80);

            g.FillRectangle(windowBrush, 280, 280, 40, 40);
            g.DrawRectangle(Pens.Blue, 280, 280, 40, 40);

            g.FillRectangle(windowBrush, 380, 280, 40, 40);
            g.DrawRectangle(Pens.Blue, 380, 280, 40, 40);

            g.FillRectangle(treeTrunkBrush, 120, 300, 30, 100);
            g.DrawRectangle(Pens.Brown, 120, 300, 30, 100);

            g.FillEllipse(treeLeavesBrush, 80, 230, 110, 90);
            g.DrawEllipse(treePen, 80, 230, 110, 90);

            Point[] road =
            {
                new Point(350, 400),
                new Point(450, 400),
                new Point(550, 550),
                new Point(250, 550)
            };
            g.FillPolygon(roadBrush, road);
            g.DrawPolygon(roadPen, road);

            for (int i = 0; i < 800; i += 20)
            {
                g.DrawLine(grassPen, i, 500, i + 5, 490);
            }

            sunPen.Dispose();
            housePen.Dispose();
            roofPen.Dispose();
            treePen.Dispose();
            roadPen.Dispose();
            grassPen.Dispose();

            skyBrush.Dispose();
            grassBrush.Dispose();
            sunBrush.Dispose();
            houseBrush.Dispose();
            roofBrush.Dispose();
            windowBrush.Dispose();
            treeTrunkBrush.Dispose();
            treeLeavesBrush.Dispose();
            roadBrush.Dispose();
        }
    }
}