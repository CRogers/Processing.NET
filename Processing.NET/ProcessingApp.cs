using System.Drawing;

namespace Processing.NET
{
    public abstract class ProcessingApp
    {
        protected int Width { get; set; }
        protected int Height { get; set; }

        protected Color Background { get; set; }
        protected Color Stroke { get; set; }


        protected ProcessingApp()
        {
            InitialSetup();
        }


        private void InitialSetup()
        {
            Width = 100;
            Height = 100;
            Background = Color.LightGray;
            Stroke = Color.Black;
        }

        protected abstract void Setup();
        protected abstract void Draw();
    }
}
