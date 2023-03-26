using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public partial class Form1
    {
        private void CreateShell_bD()
        {
            PointsCounter.Text = "d";
            for (int i = 0; i < chPoints.Count - 1; i++)
            {
                for (int j = i + 1; j < chPoints.Count; j++)
                {
                    if (CheckIfBorder(i, j))
                    {
                        chPoints[i].IsShell = true;
                        chPoints[j].IsShell = true;
                    }
                }
            }
            DeleteNonShellPoints(chPoints);
        }

        private void CreateShell_bJ()
        {
            PointsCounter.Text = "j";
            Vertex startP = FindFirstPoint();
            points[points.IndexOf(startP)].IsShell = true;

            Vector v0;
            Vertex p0 = startP;
            Vertex p1 = FindNextPoint(new Vector(1, 0), p0);

            points[points.IndexOf(p1)].IsShell = true;
            while (p1 != startP)
            {
                v0 = new Vector(p1.X - p0.X, p1.Y - p0.Y);
                p0 = p1;

                p1 = FindNextPoint(v0, p0);
                points[points.IndexOf(p1)].IsShell = true;
            }
            DeleteNonShellPoints(chPoints);
        }
    }
}
