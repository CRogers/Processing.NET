using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Processing.NET
{
    public abstract class ProcessingApp : GameWindow
    {
        private Color background;
        private Color stroke;

        protected ProcessingApp() : base(800, 600, GraphicsMode.Default, "Processing.NET")
        {
            InitialSetup();
            Setup();
        }


        private void InitialSetup()
        {
            Width = 800;
            Height = 600;
            Background(Color.Crimson);
        }

        protected virtual void Setup()
        {
        }

        protected abstract void Draw();


        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            Draw();
        }



        protected void Background(Color c)
        {
            background = c;
            GL.ClearColor(c);
        }
    }
}
