using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Timers;

namespace WindowsFormsApp3
{
    [Serializable]
    public partial class Form1 : Form
    {
        #region initialiser & var-s setting
        public Form1()
        {
            InitializeComponent();
            Refresh();
        }

        //Vertex point = new Vertex(100, 100, 10, 0);
        List<Vertex> points = new List<Vertex>();
        List<Vertex> initPoints = new List<Vertex>();
        List<Action> actions = new List<Action>();
        int actionID = -1;
        Random rnd = new Random();
        System.Timers.Timer tmr = new System.Timers.Timer(10);
        float initX = -1;
        float initY = -1;
        bool wasAnyPointTouched = false;
        bool isFigureCarried = false;
        Shapes shape = Shapes.Circle;
        Color color = Color.Black;
        bool jarv = true;
        bool checkPerfB = false;
        bool checkPerfJ = false;
        bool saveIsActual = true;
        string filename;
        int radius = 10;
        bool radiusIsBeingChanged = false;
        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
            PointsCounter.Text = points.Count.ToString();
            if (points.Count >= 3)
            {
                if (jarv) CreateShell_bJ(e.Graphics);
                else CreateShell_bD(e.Graphics);
                if (!points[points.Count - 1].IsShell && !wasAnyPointTouched) isFigureCarried = true;
                DeleteNonShellPoints(points);
            }
            foreach (Vertex point in points) point.Draw(e.Graphics, color);
            saveIsActual = false;
        }

        #region Undo/Redo
        private void AddAction(Action action) 
        {
            if (actionID != actions.Count - 1)
            {
                for(int i = actionID + 1; i < actions.Count; i++)
                {
                    actions.RemoveAt(actionID);
                }
            }
            actionID++;
            ActionsCounter.Text = actionID.ToString();
            actions.Add(action);
        }

        private void Undo_button_Click(object sender, EventArgs e)
        {
            if (actionID != -1)
            {
                actions[actionID].Undo(ref points);
                actionID--;
                ActionsCounter.Text = actionID.ToString();
            }
            Refresh();
        }

        private void Redo_button_Click(object sender, EventArgs e)
        {
            if(actionID != actions.Count - 1)
            {
                actionID++;
                actions[actionID].Redo(ref points);
                ActionsCounter.Text = actionID.ToString();
                Refresh();
            }
            Refresh();
        }

        private Vertex[] GetDeletedPoints(List<Vertex> iPs, List<Vertex> rPs)
        {
            List<Vertex> result = new List<Vertex>();
            foreach(Vertex iP in iPs)
            {
                if (GetPointID(rPs, iP) == -1) result.Add(iP);
            }
            return result.ToArray();
        }

        private static int GetPointID(List<Vertex> points, Vertex point)
        {
            int ans = -1;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X == point.X && points[i].Y == point.Y) { ans = i; break; }
            }
            return ans;
        }
        #endregion




        #region Canvas_clicks_handler
        private void AddPoint(int mX, int mY)
        {
            switch (shape)
            {
                case Shapes.Circle: points.Add(new Circle(mX, mY, radius)); break;
                case Shapes.Square: points.Add(new Square(mX, mY, radius)); break;
                case Shapes.Triangle: points.Add(new Triangle(mX, mY, radius)); break;
                default: points.Add(new Circle(mX, mY, radius)); break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int hitnum = -1;
            PointsCounter.Text = "MD";
            wasAnyPointTouched = false;
            foreach (Vertex point in points)
            {
                if (e.Button == MouseButtons.Left && point.IsTouched(e.X, e.Y))
                {
                    point.Carried = true;
                    initX = e.X;
                    initY = e.Y;
                    initPoints = points;
                    wasAnyPointTouched = true;
                }
                else if (point.IsTouched(e.X, e.Y))
                {
                    hitnum = points.IndexOf(point);
                    wasAnyPointTouched = true;
                }
            }

            if (!wasAnyPointTouched)
            {
                AddPoint(e.X, e.Y);
                initPoints = points;
                Refresh();
                Vertex[] killedPoints = GetDeletedPoints(initPoints, points);
                DeletedPointsCounter.Text = killedPoints.Length.ToString();
                AddAction(new AddPoint(points[points.Count - 1], GetDeletedPoints(initPoints, points)));
            }

            if (hitnum != -1)
            {
                AddAction(new DeletePoint(points[hitnum]));
                points.RemoveAt(hitnum);
                Refresh();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isFigureCarried)
                {
                    foreach (Vertex p in points) p.Move(e.X, e.Y);
                    if (initX == -1)
                    {
                        initX = e.X;
                        initY = e.Y;
                    }
                    Refresh();
                }

                for (int i = 0; i < points.Count(); i++)
                {
                    if (points[i].Carried)
                    {
                        points[i].Move(e.X, e.Y);
                        Refresh();
                    }
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            List<Vertex> movedPoints = new List<Vertex>();
            bool carried = false;
            foreach (Vertex point in points)
            {
                if (point.Carried)
                {
                    movedPoints.Add(point);
                    point.Carried = false;
                    carried = true;
                }
            }
            if(carried)
            {
                Vertex[] killedPoints = GetDeletedPoints(initPoints, points);
                DeletedPointsCounter.Text = killedPoints.Length.ToString();
                AddAction(new MovePoints(movedPoints, GetDeletedPoints(initPoints, points), initX, initY, e.X, e.Y));
                initPoints = new List<Vertex>();
            }
            
            if (isFigureCarried)
            {
                AddAction(new MovePolygon(initX, initY, e.X, e.Y));
                isFigureCarried = false;
            }
            initX = -1;
            initY = -1;
        }
        #endregion
        
        #region Save/Load
        private void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, points);
            fs.Close();
            saveIsActual = true;
        }

        private void SaveFileAs()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Polygon files: (*.bin)|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                Save();
            }
        }

        private void Open()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Polygon files: (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;

                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                points = (List<Vertex>)bf.Deserialize(fs);
                fs.Close();
                saveIsActual = true;
            }
        }

        private void Save_handling()
        {
            if (!saveIsActual) //check, if we need to save
            {
                if (filename != null) Save();
                else SaveFileAs();
            }
        }

        private void AskToSaveFile()
        {
            if (MessageBox.Show("Save file?", "Current file is not saved", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Save_handling();
            }
        }
        #endregion

        #region Shell_by_default
        private void CreateShell_bD(Graphics g)
        {
            PointsCounter.Text = "d";
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (CheckIfBorder(i, j))
                    {
                        if (!checkPerfB && !checkPerfJ) g.DrawLine(new Pen(Brushes.Black), points[i].X, points[i].Y, points[j].X, points[j].Y);
                        points[i].IsShell = true;
                        points[j].IsShell = true;
                    }
                }
            }
        }

        private List<Vertex> DeleteNonShellPoints(List<Vertex> ps)
        {
            for (int i = 0; i < ps.Count(); i++)
            {
                if (!ps[i].IsShell)
                {
                    ps.RemoveAt(i);
                    i--;
                }
                else ps[i].IsShell = false;
            }
            return ps;
        }

        private bool CheckIfBorder(int i, int j)
        {
            if (points[i].X == points[j].X) return CheckIfBorderUpright(points[i].X, i, j);

            float k = (points[j].Y - points[i].Y) / (points[j].X - points[i].X);
            float b = points[i].Y - points[i].X * k;
            //g.DrawLine(new Pen(Brushes.LightBlue), 0, b, 10000, 10000 * k + b);

            List<Vertex> pointsForChecking = new List<Vertex>(points);
            pointsForChecking.RemoveAt(i);
            pointsForChecking.RemoveAt(j - 1);
            for (int l = 0; l < pointsForChecking.Count - 1; l++)
            {
                if (CheckIfUpperThanLine(k, b, pointsForChecking[l]) != CheckIfUpperThanLine(k, b, pointsForChecking[l + 1])) return false;
            }
            return true;
        }

        private bool CheckIfBorderUpright(float x, int i, int j)
        {
            List<Vertex> pointsForChecking = new List<Vertex>(points);
            pointsForChecking.RemoveAt(i);
            pointsForChecking.RemoveAt(j - 1);
            for (int l = 1; l < pointsForChecking.Count; l++)
            {
                if (CheckIfLeftLine(x, pointsForChecking[l]) != CheckIfLeftLine(x, pointsForChecking[l - 1])) return false;
            }
            return true;
        }

        private bool CheckIfUpperThanLine(float k, float b, Vertex point)
        {
            if (point.X * k + b < point.Y) return false;
            else return true;
        }

        private bool CheckIfLeftLine(float x, Vertex point)
        {
            if (point.X < x) return true;
            else return false;
        }
        #endregion

        #region Shell_by_Jarvis
        private void CreateShell_bJ(Graphics g)
        {
            //PointsCounter.Text = "j";
            Vertex startP = FindFirstPoint();
            points[points.IndexOf(startP)].IsShell = true;

            Vector v0;
            Vertex p0 = startP;
            Vertex p1 = FindNextPoint(new Vector(1, 0), p0);

            points[points.IndexOf(p1)].IsShell = true;
            if (!checkPerfB && !checkPerfJ) g.DrawLine(new Pen(Brushes.Black), p0.X, p0.Y, p1.X, p1.Y);
            while (p1 != startP)
            {
                v0 = new Vector(p1.X - p0.X, p1.Y - p0.Y);
                p0 = p1;

                p1 = FindNextPoint(v0, p0);
                points[points.IndexOf(p1)].IsShell = true;
                if (!checkPerfB && !checkPerfJ) g.DrawLine(new Pen(Brushes.Black), p0.X, p0.Y, p1.X, p1.Y);
            }
        }
        private Vertex FindFirstPoint()
        {
            float min = -1.0f;
            List<Vertex> firstPs = new List<Vertex>();
            foreach (Vertex p in points)
            {
                if (p.Y > min)
                {
                    min = p.Y;
                    firstPs.Clear();
                    firstPs.Add(p);
                }
                else if (p.Y == min) firstPs.Add(p);
            }

            if (firstPs.Count == 1) { return firstPs[0]; }
            else
            {
                float maxX = 0.0f;
                Vertex firstP = null;
                foreach (Vertex p in points)
                {
                    if (p.X > maxX)
                    {
                        maxX = p.X;
                        firstP = p;
                    }
                }
                return firstP;
            }
        }

        private Vertex FindNextPoint(Vector v0, Vertex p0)
        {
            float maxCos = -1.0001f;
            Vertex p1 = null;
            Vector v1;
            foreach (Vertex p in points)
            {
                if (p == p0) continue;
                v1 = new Vector(p.X - p0.X, p.Y - p0.Y);
                if (Cos(v0, v1) > maxCos)
                {
                    maxCos = Cos(v0, v1);
                    p1 = p;
                }
            }
            return p1;
        }


        private float Cos(Vector v0, Vector v1)
        {
            //PointsCounter.Text += "\n" + (Prod(v0, v1) / Len(v0) / Len(v1)).ToString();
            return Prod(v0, v1) / Len(v0) / Len(v1);
        }

        private float Len(Vector v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        private float Prod(Vector v0, Vector v1)
        {
            return v0.X * v1.X + v0.Y * v1.Y;
        }
        #endregion

        #region Radius
        void UpdateRadius(object Sender, RadiusEventArgs re)
        {
            if (re.radius == -1)
            {
                radiusIsBeingChanged = false;
                return;
            }
            radius = re.radius;
            foreach (Vertex p in points)
            {
                p.radius = radius;
            }
            Refresh();
        }

        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.RadiusChanged += new RadiusChangedDelegate(UpdateRadius);
            F2.Show();
        }
        #endregion

        #region Shaking
        private void timer1_Tick(object sender, EventArgs e)
        {

            foreach (Vertex point in points)
            {
                point.X += rnd.Next(-1, 2);
                point.Y += rnd.Next(-1, 2);
            }
            Refresh();
        }
        #endregion

        #region MenuStrip_clicks_handler
        #region FigureOptions_clicks_handler
        private void circleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "C";
            if (circleToolStripMenuItem.Checked) shape = Shapes.Circle;
        }

        private void squareToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "S";
            if (squareToolStripMenuItem.Checked) shape = Shapes.Square;
        }

        private void triangleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "T";
            if (triangleToolStripMenuItem.Checked) shape = Shapes.Triangle;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "C";
            shape = Shapes.Circle;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "S";
            shape = Shapes.Square;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "T";
            shape = Shapes.Triangle;
        }
        #endregion

        #region Shell_Methods_handler
        private void byDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byDefinitionToolStripMenuItem.Checked = true;
            jarvisToolStripMenuItem.Checked = false;
            jarv = false;
            checkPerfB = false;
            checkPerfJ = false;
        }

        private void jarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byDefinitionToolStripMenuItem.Checked = false;
            jarvisToolStripMenuItem.Checked = true;
            jarv = true;
            checkPerfB = false;
            checkPerfJ = false;
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Random rnd = new Random();
            checkPerfB = true;
            jarv = false;
            checkPerfJ = false;

            double[] timesArr_j = new double[10];
            double[] timesArr_d = new double[10];
            Chart chart = new Chart();
            chart.Show();
            for (int i = 0; i < timesArr_j.Length; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    chPoints.Add(new Circle((float)rnd.NextDouble() * 10000f, (float)rnd.NextDouble() * 10000f, 10));
                }
                List<Vertex> chPoints_mirror = chPoints; 

                DateTime start = DateTime.Now;
                CreateShell_bD();
                DateTime end = DateTime.Now;

                TimeSpan ts = end - start;
                timesArr_d[i] = ts.TotalSeconds;

                chPoints = chPoints_mirror;

                start = DateTime.Now;
                CreateShell_bD();
                end = DateTime.Now;

                ts = end - start;
                timesArr_d[i] = ts.TotalSeconds;
            }

            chart.DrawChart(timesArr_j, timesArr_d);*/
        }

        private void checkPerfJarvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Random rnd = new Random();
            checkPerfJ = true;
            jarv = false;
            checkPerfB = false;

            double[] timesArr = new double[10];
            Chart chart = new Chart();
            chart.Show();
            for (int i = 0; i < timesArr.Length; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    chPoints.Add(new Circle((float)rnd.NextDouble() * 10000f, (float)rnd.NextDouble() * 10000f, 10));
                }
                DateTime start = DateTime.Now;
                CreateShell_bJ();
                DateTime end = DateTime.Now;

                TimeSpan ts = end - start;
                timesArr[i] = ts.TotalSeconds;
            }
            chart.DrawChart(timesArr);*/
        }
        #endregion

        #region Save/Load_buttons_handler
        private void newFile_Click(object sender, EventArgs e)
        {
            AskToSaveFile();
            points = new List<Vertex>();
            Refresh();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            AskToSaveFile();
            Open();
            Refresh();
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            Save_handling();
        }

        private void saveFileAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }
        #endregion

        #region Shaking_buttons_handler
        private void startShaking_button_Click(object sender, EventArgs e)
        {
            //shaking = true;
            timer1.Start();
        }

        private void stopShaking_button_Click(object sender, EventArgs e)
        {
            //shaking = false;
            timer1.Stop();
        }
        #endregion

        

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                Refresh();
            }
        }
        #endregion
    }

    public delegate void RadiusChangedDelegate(object sender, RadiusEventArgs re);

    public class RadiusEventArgs : EventArgs
    {
        public int radius;
        public RadiusEventArgs(int radius)
        {
            this.radius = radius;
        }
    }

}
