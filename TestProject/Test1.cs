using System.Drawing;
using Processing.NET;

namespace TestProject
{
    public class Test1 : ProcessingApp
    {
        private int step = 0;
        private int x = 0, y = 0;

        protected override void Draw()
        {
            Background(Color.FromArgb(step, step, step));
            step = (step + 1)%255;

            Fill = Color.Crimson;
            Rect(x = (++x % Width),y = (++y % Height),100,100);

            Fill = Color.ForestGreen;
            Point(Width-100, 50);

            Stroke = Color.Green;
            Line(300,10,500,300);

            Stroke = Color.DeepSkyBlue;
            Fill = Color.DodgerBlue;
            Triangle(100,100,150,100,125,150);
        }
    }
}
