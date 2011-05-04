using System.Drawing;
using Processing.NET;

namespace TestProject
{
    public class Test1 : ProcessingApp
    {
        private int step = 0;

        protected override void Draw()
        {
            Background(Color.FromArgb(step, step, step));
            step = (step + 1)%255;

            Fill = Color.Crimson;
            Rect(10,10,200,200);
        }
    }
}
