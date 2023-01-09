using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private void CreateShell()
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i; j < points.Count; j++)
                {
                    if (points.Count != 3)
                    {
                        if (CheckIfBorder(i, j)) g.DrawLine(new Pen(Brushes.Black), points[i].X, points[i].Y, points[j].X, points[j].Y);
                    }
                    else g.DrawLine(new Pen(Brushes.Black), points[i].X, points[i].Y, points[j].X, points[j].Y);
                    //else g.DrawLine(new Pen(Brushes.Red), points[i].X, points[i].Y, points[j].X, points[j].Y);
                }
            }
        }

        private bool CheckIfBorder(int i, int j)
        {
            if (points[i].X == points[j].X) return CheckIfBorderUpright(points[i].X);

            float k = (points[j].Y - points[i].Y) / (points[j].X - points[i].X);
            float b = points[i].Y - points[i].X * k;

            List<Vertex> pointsForChecking = points;
            pointsForChecking.RemoveAt(i);
            pointsForChecking.RemoveAt(j - 1);
            for (int k = 1; k < pointsForChecking.Count; k++)
            {
                if (CheckIfUpperThanLine()) ;
            }
            /*int isUpper = CheckIfUpperLine(k, b, points[0]);
            for (int i = 1; i < points.Count; i++)
            {
                if (isUpper != 0 && CheckIfUpperLine(k, b, points[i]) != 0 && isUpper != CheckIfUpperLine(k, b, points[i])) return false;
                isUpper = CheckIfUpperLine(k, b, points[i]);
            }*/
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