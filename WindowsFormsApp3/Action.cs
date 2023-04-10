using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal abstract class Action
    {
        public abstract void Undo(ref List<Vertex> points);
        public abstract void Redo(ref List<Vertex> points);
    }

    internal class MovePoints : Action
    {
        Vertex[] movedPoints, killedPoints;
        float shiftX, shiftY;
        public MovePoints(List<Vertex> Mpoints, Vertex[] Kpoints, float initX, float initY, float x, float y) 
        {
            killedPoints = Kpoints;
            movedPoints = new Vertex[Mpoints.Count];
            for (int i = 0; i < Mpoints.Count; i++)
            {
                movedPoints[i] = Mpoints[i];
            }
            shiftX = x - initX;
            shiftY = y - initY;
        }

        public override void Undo(ref List<Vertex> points)
        {
            foreach(Vertex p in movedPoints)
            { 
                int id = points.IndexOf(p);
                points[id].X -= shiftX;
                points[id].Y -= shiftY;
            }
            foreach(Vertex p in killedPoints)
            {
                points.Add(p);
            }
        }

        public override void Redo(ref List<Vertex> points)
        {
            foreach (Vertex p in movedPoints)
            {
                int id = points.IndexOf(p);
                points[id].X += shiftX;
                points[id].Y += shiftY;
            }
            foreach (Vertex p in killedPoints)
            {
                points.Remove(p);
            }
        }
    }

    internal class MovePolygon : Action
    {
        float shiftX, shiftY;
        public MovePolygon(float initX, float initY, float x, float y)
        {
            shiftX = x - initX;
            shiftY = y - initY;
        }

        public override void Undo(ref List<Vertex> points)
        {
            foreach (Vertex p in points)
            {
                p.X -= shiftX;
                p.Y -= shiftY;
            }
        }

        public override void Redo(ref List<Vertex> points)
        {
            foreach (Vertex p in points)
            {
                p.X += shiftX;
                p.Y += shiftY;
            }
        }
    }

    internal class DeletePoint : Action
    {
        Vertex point;
        public DeletePoint(Vertex point)
        {
            this.point = point;
        }
        public override void Undo(ref List<Vertex> points)
        {
            points.Add(point);
        }

        public override void Redo(ref List<Vertex> points)
        {
            points.Remove(point);
        }
    }

    internal class AddPoint : Action
    {
        Vertex point;
        public AddPoint(Vertex point)
        {
            this.point = point;
        }

        public override void Undo(ref List<Vertex> points)
        {
            points.Remove(point);
        }

        public override void Redo(ref List<Vertex> points)
        {
            points.Add(point);
        }
    }
}
