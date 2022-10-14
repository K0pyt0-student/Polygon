using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
    enum Shapes {Circle, Square, Triangle }
    internal class Vertex
    {
        private int x;
        private int y;
        private int r;
        private bool IsBeingCarried;
        private int shiftX;
        private int shiftY;
        private Shapes shape;
        private Point[] points = new Point[3];

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            switch (shape)
            {
                case Shapes.Circle: g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r); break;
                case Shapes.Square: g.FillRectangle(brush, x - r, y - r, 2 * r, 2 * r); break;
                case Shapes.Triangle: g.FillPolygon(brush, points); break;
            }
        }

        public bool IsTouched(int MouseX, int MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            switch (shape)
            {
                case Shapes.Circle: return Math.Pow(shiftX, 2) + Math.Pow(shiftY, 2) <= r * r;
                case Shapes.Square: return Math.Abs(shiftX) <= r && Math.Abs(shiftY) <= r;
                case Shapes.Triangle: return shiftY <= r && shiftY >= - 2 / Math.Sqrt(3) * shiftX - r && shiftY >= 2 / Math.Sqrt(3) * shiftX - r;
                default: return false;
            }
        }

        public void Move(int mouseX, int mouseY)
        {
            x = mouseX - shiftX;
            y = mouseY - shiftY;
            points[0] = new Point(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
            points[1] = new Point(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
            points[2] = new Point(x, y - r);
        }

        public Vertex()
        {
            x = 100;
            y = 100;
            r = 10;
            IsBeingCarried = false;
            shape = Shapes.Circle;
        }

        public Vertex(int x, int y, int r, Shapes shape)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            IsBeingCarried = false;
            this.shape = shape;
            if (shape == Shapes.Triangle)
            {
                points[0] = new Point(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
                points[1] = new Point(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
                points[2] = new Point(x, y - r);
            }
        }

        public bool Carried
        {
            get { return IsBeingCarried; }
            set { IsBeingCarried = value; }

        }
    }
}
