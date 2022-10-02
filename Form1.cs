namespace Polygon
{
    public partial class Form1 : Form
    {
        Vertex point = new Vertex(100, 100, 10, 0);

        public Form1()
        {
            InitializeComponent();
            //Graphics g = CreateGraphics();
            //Vertex point = new Vertex(100, 100, 10, 0, g);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            point.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && point.IsTouched(e.X, e.Y)) point.Carried = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && point.Carried)
            {
                point.Move(e.X, e.Y);
            } 
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}