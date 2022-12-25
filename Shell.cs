using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon
{
    public partial class Form1 : Form
    {
        private void CreateShell()
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < points.Count; i++)
            {
                for(int j = i + 1; j < points.Count; j++)
                {
                    if (CheckIfBorder(points[i].X, points[i].Y, points[j].X, points[j].Y)) g.DrawLine(new Pen(Brushes.Black), points[i].X, points[i].Y, points[j].X, points[j].Y);
                    //else g.DrawLine(new Pen(Brushes.Red), points[i].X, points[i].Y, points[j].X, points[j].Y);
                }
            }
        }
        
        private bool CheckIfBorder(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2) return CheckIfBorderUpright(x1);
            float k = (y2 - y1) / (x2 - x1);
            float b = y1 - x1 * k;
            int isUpper = CheckIfUpperLine(k, b, points[0]);
            for (int i = 1; i < points.Count; i++)
            {
                if (isUpper != 0 && CheckIfUpperLine(k, b, points[i]) != 0 && isUpper != CheckIfUpperLine(k, b, points[i])) return false;
                isUpper = CheckIfUpperLine(k, b, points[i]);
            }
            return true;
        }

        private bool CheckIfBorderUpright(int x)
        {
            int isLeft = CheckIfLeftLine(x, points[0]);
            for (int i = 1; i < points.Count; i++)
            {
                if (isLeft != 0 && CheckIfLeftLine(x, points[i]) != 0) if (isLeft != CheckIfLeftLine(x, points[i])) return false;
                isLeft = CheckIfLeftLine(x, points[i]);
            }
            return true;
        } 

        private int CheckIfUpperLine(float k, float b, Vertex point)
        {
            if (point.X * k + b < point.Y) return -1;
            else if (point.X * k + b > point.Y) return 1;
            else return 0;
        }

        private int CheckIfLeftLine(int x, Vertex point)
        {
            if (point.X < x) return 1;
            else if (point.X > x) return -1;
            else return 0;
        }
        
    }
}
