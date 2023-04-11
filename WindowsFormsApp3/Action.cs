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
        public abstract void Undo(ref List<Vertex> points, ref int r, ref Color c);
        public abstract void Redo(ref List<Vertex> points, ref int r, ref Color c);
        public abstract bool IsShaking { get; }
        protected static int GetPointID(List<Vertex> points, Vertex point)
        {
            int ans = -1;
            for (int i = 0; i < points.Count; i++) 
            { 
                if (points[i].X == point.X && points[i].Y == point.Y) { ans = i; break; }
            }
            return ans;
        }
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
        public override bool IsShaking
        { get { return false; } }

        public override void Undo(ref List<Vertex> points, ref int r, ref Color c)
        {
            foreach(Vertex p in movedPoints)
            { 
                int id = GetPointID(points, p);
                points[id].X -= shiftX;
                points[id].Y -= shiftY;
            }
            foreach(Vertex p in killedPoints)
            {
                points.Add(p);
            }
        }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c)
        {
            foreach (Vertex p in movedPoints)
            {
                int id = GetPointID(points, p);
                points[id].X += shiftX;
                points[id].Y += shiftY;
            }
            foreach (Vertex p in killedPoints)
            {
                points.RemoveAt(GetPointID(points, p));
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
        public override bool IsShaking
        { get { return false; } }

        public override void Undo(ref List<Vertex> points, ref int r, ref Color c)
        {
            foreach (Vertex p in points)
            {
                p.X -= shiftX;
                p.Y -= shiftY;
            }
        }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c)
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
        public override bool IsShaking
        { get { return false; } }

        public override void Undo(ref List<Vertex> points, ref int r, ref Color c)
        {
            points.Add(point);
        }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c)
        {
            points.RemoveAt(GetPointID(points, point));
        }
    }

    internal class AddPoint : Action
    {
        Vertex point;
        Vertex[] killedPoints; 
        public AddPoint(Vertex point, Vertex[] Kpoints)
        {
            killedPoints = Kpoints;
            this.point = point;
        }

        public override void Undo(ref List<Vertex> points, ref int r, ref Color c)
        {
            points.Remove(point);
            foreach (Vertex p in killedPoints)
            {
                points.Add(p);
            }
        }
        public override bool IsShaking
        { get { return false; } }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c)
        {
            points.Add(point);
            foreach (Vertex p in killedPoints)
            {
                points.RemoveAt(GetPointID(points, p));
            }
        }
    }

    internal class ChangeRadius : Action
    {
        int shift;
        
        public ChangeRadius(int initR, int rR)
        {
            shift = rR - initR;
        }
        public override bool IsShaking
        { get { return false; } }

        public override void Undo(ref List<Vertex> points, ref int r, ref Color c)
        {
            r -= shift; 
            foreach(Vertex p in points)
            {
                p.radius = r;
            }

        }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c)
        { 
            r += shift;
            foreach (Vertex p in points)
            {
                p.radius = r;
            }
        }
    }

    internal class ChangeColor : Action
    {
        Color initColor, resColor;
        public ChangeColor(Color initC, Color resC)
        {
            initColor = initC;
            resColor = resC;
        }
        public override bool IsShaking
        { get { return false; } }
        public override void Undo(ref List<Vertex> points, ref int r, ref Color c) { c = initColor; }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c) {c = resColor;}
    }

    internal class Shaking : Action
    {
        Vertex[] initPoints, resPoints;
        public Shaking(Vertex[] initP, Vertex[] resP)
        {
            initPoints = initP;
            resPoints = resP;
        }
        public override bool IsShaking
        { get { return true; } }
        public override void Undo(ref List<Vertex> points, ref int r, ref Color c) { points = initPoints.ToList(); }

        public override void Redo(ref List<Vertex> points, ref int r, ref Color c) { points = resPoints.ToList(); }
    }
}
