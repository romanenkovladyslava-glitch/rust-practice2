using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StarsPractice
{
    public partial class Form1 : Form
    {
        private readonly List<StarShape> shapes = new List<StarShape>();
        private Bitmap canvasBitmap;

        private Color currentFillColor = Color.Gold;
        private Color currentBorderColor = Color.Black;

        public Form1()
        {
            InitializeComponent();
            InitializeUi();
            InitializeCanvas();
        }

        private void InitializeUi()
        {
            comboBoxStarType.Items.AddRange(new string[]
            {
                "П'ятикутна зірка",
                "Шестикутна зірка",
                "Восьмикутна зірка"
            });
            comboBoxStarType.SelectedIndex = 0;

            numericUpDownSize.Minimum = 20;
            numericUpDownSize.Maximum = 300;
            numericUpDownSize.Value = 80;

            numericUpDownX.Minimum = 0;
            numericUpDownY.Minimum = 0;

            buttonFillColor.BackColor = currentFillColor;
            buttonBorderColor.BackColor = currentBorderColor;

            pictureBoxCanvas.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCanvas.BackColor = Color.White;

            buttonFillColor.Click += buttonFillColor_Click;
            buttonBorderColor.Click += buttonBorderColor_Click;
            buttonAdd.Click += buttonAdd_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonClear.Click += buttonClear_Click;
            pictureBoxCanvas.Resize += pictureBoxCanvas_Resize;
        }

        private void InitializeCanvas()
        {
            if (pictureBoxCanvas.Width <= 0 || pictureBoxCanvas.Height <= 0)
                return;

            canvasBitmap?.Dispose();
            canvasBitmap = new Bitmap(pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            pictureBoxCanvas.Image = canvasBitmap;

            numericUpDownX.Maximum = pictureBoxCanvas.Width;
            numericUpDownY.Maximum = pictureBoxCanvas.Height;

            RedrawCanvas();
        }

        private void pictureBoxCanvas_Resize(object sender, EventArgs e)
        {
            InitializeCanvas();
        }

        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = currentFillColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFillColor = colorDialog1.Color;
                buttonFillColor.BackColor = currentFillColor;
            }
        }

        private void buttonBorderColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = currentBorderColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentBorderColor = colorDialog1.Color;
                buttonBorderColor.BackColor = currentBorderColor;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (canvasBitmap == null)
                return;

            StarType type = (StarType)comboBoxStarType.SelectedIndex;
            int size = (int)numericUpDownSize.Value;
            float x = (float)numericUpDownX.Value;
            float y = (float)numericUpDownY.Value;

            StarShape shape = new StarShape
            {
                Type = type,
                Center = new PointF(x, y),
                Size = size,
                FillColor = currentFillColor,
                BorderColor = currentBorderColor
            };

            shapes.Add(shape);
            listBoxObjects.Items.Add(shape);

            RedrawCanvas();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxObjects.SelectedIndex;
            if (index < 0 || index >= shapes.Count)
            {
                MessageBox.Show("Оберіть об'єкт для видалення.");
                return;
            }

            shapes.RemoveAt(index);
            listBoxObjects.Items.RemoveAt(index);

            RedrawCanvas();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            listBoxObjects.Items.Clear();
            RedrawCanvas();
        }

        private void RedrawCanvas()
        {
            if (canvasBitmap == null)
                return;

            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                foreach (StarShape shape in shapes)
                {
                    DrawStar(g, shape);
                }
            }

            pictureBoxCanvas.Invalidate();
        }

        private void DrawStar(Graphics g, StarShape shape)
        {
            PointF[] points = GetStarPoints(shape.Type, shape.Center, shape.Size);

            using (SolidBrush brush = new SolidBrush(shape.FillColor))
            using (Pen pen = new Pen(shape.BorderColor, 2))
            {
                g.FillPolygon(brush, points);
                g.DrawPolygon(pen, points);
            }
        }

        private PointF[] GetStarPoints(StarType type, PointF center, float size)
        {
            PointF[] relativePoints;

            switch (type)
            {
                case StarType.FivePointed:
                    relativePoints = CreateFivePointedStarRelative();
                    break;

                case StarType.SixPointed:
                    relativePoints = CreateSixPointedStarRelative();
                    break;

                case StarType.EightPointed:
                    relativePoints = CreateEightPointedStarRelative();
                    break;

                default:
                    relativePoints = CreateFivePointedStarRelative();
                    break;
            }

            float scale = size / 2f;

            PointF[] result = new PointF[relativePoints.Length];
            for (int i = 0; i < relativePoints.Length; i++)
            {
                result[i] = new PointF(
                    center.X + relativePoints[i].X * scale,
                    center.Y + relativePoints[i].Y * scale
                );
            }

            return result;
        }

        private PointF[] CreateFivePointedStarRelative()
        {
            List<PointF> points = new List<PointF>();
            double outerRadius = 1.0;
            double innerRadius = 0.45;
            double startAngle = -Math.PI / 2;

            for (int i = 0; i < 10; i++)
            {
                double angle = startAngle + i * Math.PI / 5;
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;

                float x = (float)(radius * Math.Cos(angle));
                float y = (float)(radius * Math.Sin(angle));
                points.Add(new PointF(x, y));
            }

            return points.ToArray();
        }

        private PointF[] CreateSixPointedStarRelative()
        {
            return new PointF[]
            {
                new PointF(0f, -1.0f),
                new PointF(0.22f, -0.38f),
                new PointF(0.87f, -0.5f),
                new PointF(0.45f, 0f),
                new PointF(0.87f, 0.5f),
                new PointF(0.22f, 0.38f),
                new PointF(0f, 1.0f),
                new PointF(-0.22f, 0.38f),
                new PointF(-0.87f, 0.5f),
                new PointF(-0.45f, 0f),
                new PointF(-0.87f, -0.5f),
                new PointF(-0.22f, -0.38f)
            };
        }

        private PointF[] CreateEightPointedStarRelative()
        {
            List<PointF> points = new List<PointF>();
            double outerRadius = 1.0;
            double innerRadius = 0.45;
            double startAngle = -Math.PI / 2;

            for (int i = 0; i < 16; i++)
            {
                double angle = startAngle + i * Math.PI / 8;
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;

                float x = (float)(radius * Math.Cos(angle));
                float y = (float)(radius * Math.Sin(angle));
                points.Add(new PointF(x, y));
            }

            return points.ToArray();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonFillColor_Click_1(object sender, EventArgs e)
        {

        }

        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public enum StarType
    {
        FivePointed = 0,
        SixPointed = 1,
        EightPointed = 2
    }

    public class StarShape
    {
        public StarType Type { get; set; }
        public PointF Center { get; set; }
        public float Size { get; set; }
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }

        public override string ToString()
        {
            string typeName = Type switch
            {
                StarType.FivePointed => "5-кутна",
                StarType.SixPointed => "6-кутна",
                StarType.EightPointed => "8-кутна",
                _ => "Зірка"
            };

            return $"{typeName} | X={Center.X}, Y={Center.Y}, Розмір={Size}";
        }
    }
}