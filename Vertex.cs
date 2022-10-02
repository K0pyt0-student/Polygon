using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
    internal class Vertex
    {
        private int x;
        private int y;
        private int z;
        private int r;
        private bool IsBeingCarried;

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);
        }

        public bool IsTouched(int MouseX, int MouseY)
        {
            return Math.Pow(MouseX - x, 2) + Math.Pow(MouseY - y, 2) <= r * r;
        }

        public void Move(int mouseX, int mouseY)
        {
            x = mouseX;
            y = mouseY;
        }

        public Vertex()
        {
            x = 100;
            y = 100;
            z = 0;
            r = 10;
            IsBeingCarried = false;
        }

        public Vertex(int x, int y, int r, int z)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            this.z = z;
            IsBeingCarried = false;
        }

        public bool Carried
        {
            get { return IsBeingCarried; }
            set { IsBeingCarried = value; }

        }
    }
}
