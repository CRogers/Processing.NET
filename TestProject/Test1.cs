using System.Drawing;
using Processing.NET;

namespace TestProject
{
    public class Test1 : ProcessingApp
    {
        private int step = 0;
        private int x = 0, y = 0;

        public Test1() : base(4)
        {
        }

        protected override void Draw()
        {
            Background(Color.FromArgb(step, step, step));
            step = (step + 1)%255;

            Fill = Color.White;
            Rect(10, 10, Width - 20, Height - 20);
            //Rect(x = (++x % Width),y = (++y % Height),100,100);

            Fill = Color.ForestGreen;
            Point(Width-100, 50);

            PushMatrix();
            Translate(100, 50);
            Stroke = Color.Green;
            Line(300,10,500,300);
            PopMatrix();

            Stroke = Color.DeepSkyBlue;
            Fill = Color.DodgerBlue;
            Triangle(MouseX,MouseY,150,100,125,150);

            //Stroke = Color.CornflowerBlue;
            //Fill = Color.DarkViolet;
            //BeginShape(ShapeMode.Lines);
            //Vertex(200,200);
            //Vertex(400,400);
            //Vertex(370,370);
            //EndShape();

            PushMatrix();
            Rotate(step/255.0*TwoPI);
            Scale(0.999);
            Ellipse(300,300,50+step/2,200);
            PopMatrix();

            Arc(100,100,50,50,HalfPI/2,HalfPI*3);

            Stroke = Color.Fuchsia;
            Line(MouseX, MouseY, PMouseX, PMouseY);
        }

        protected override void OnMousePressed()
        {
            Rect(MouseX, MouseY, 100, 100);
        }
    }
}
