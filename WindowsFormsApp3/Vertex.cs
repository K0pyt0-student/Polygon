using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    enum Shapes { Circle, Square, Triangle }
    internal abstract class Vertex
    {
        protected int x;
        protected int y;
        protected int r;
        protected bool IsBeingCarried;
        protected int shiftX;
        protected int shiftY;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public abstract void Draw(Graphics g);
        public abstract bool IsTouched(int MouseX, int MouseY);


        public virtual void Move(int mouseX, int mouseY)
        {
            x = mouseX - shiftX;
            y = mouseY - shiftY;
        }

        public Vertex()
        {
            x = 100;
            y = 100;
            r = 10;
            IsBeingCarried = false;
        }

        public Vertex(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            IsBeingCarried = false;
        }

        public bool Carried
        {
            get { return IsBeingCarried; }
            set { IsBeingCarried = value; }
        }
    }

    internal class Сircle : Vertex
    {
        public Сircle(int x, int y, int r) : base(x, y, r) { }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);
        }

        public override bool IsTouched(int MouseX, int MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return shiftX * shiftX + shiftY * shiftY <= r * r;
        }
    }

    internal class Square : Vertex
    {
        public Square(int x, int y, int r) : base(x, y, r) { }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, x - r, y - r, 2 * r, 2 * r);
        }

        public override bool IsTouched(int MouseX, int MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return Math.Abs(shiftX) <= r && Math.Abs(shiftY) <= r;
        }
    }

    internal class Triangle : Vertex
    {
        private Point[] points = new Point[3];
        public Triangle(int x, int y, int r) : base(x, y, r)
        {
            points[0] = new Point(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
            points[1] = new Point(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
            points[2] = new Point(x, y - r);
        }

        public override void Move(int mouseX, int mouseY)
        {
            base.Move(mouseX, mouseY);
            points[0] = new Point(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
            points[1] = new Point(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
            points[2] = new Point(x, y - r);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillPolygon(brush, points);
        }

        public override bool IsTouched(int MouseX, int MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return shiftY <= r && shiftY >= -2 / Math.Sqrt(3) * shiftX - r && shiftY >= 2 / Math.Sqrt(3) * shiftX - r;
        }
    }
}
