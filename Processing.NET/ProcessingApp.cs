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

        protected Color Stroke { get; set; }
        protected Color Fill { get; set; }

        protected ProcessingApp() : base(800, 600, GraphicsMode.Default, "Processing.NET")
        {
        }


        private void InitialSetup()
        {
            Width = 800;
            Height = 600;
            Background(Color.Gray);
        }

        protected virtual void Setup()
        {
        }

        private void PostSetup()
        {
            GL.Viewport(0,0,Width,Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1,1,-1,1,-1,1);
        }

        protected abstract void Draw();


        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            InitialSetup();
            Setup();
        }
        

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Draw();

            SwapBuffers();
        }



        private void Sxy(ref double x, ref double y)
        {
            x = x/Width*2 - 1.0;
            y = 1.0 - y/Height*2;
        }

        private void Swh(ref double w, ref double h)
        {
            w = w / Width * 2;
            h = h / Height * -2;
        }


        protected void Background(Color c)
        {
            background = c;
            GL.ClearColor(c);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        protected void Rect(double x, double y, double width, double height)
        {
            Sxy(ref x, ref y);
            Swh(ref width, ref height);
            GL.Color4(Fill);

            GL.Rect(x,y,x+width,y+height);
        }
    }
}
