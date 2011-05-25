using System;
using System.Collections.Generic;
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

        protected const double HalfPI = Math.PI/2.0;
        protected const double PI = Math.PI;
        protected const double TwoPI = Math.PI*2;


        protected double MouseX
        {
            get { return Mouse.X; }
        }

        protected double MouseY
        {
            get { return Mouse.Y;  }
        }


        protected ProcessingApp(int smoothSamples = 1) : base(800, 600, new GraphicsMode(32,24,8,smoothSamples), "Processing.NET")
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
            Quad(x, y, x + width, y, x + width, y + height, x, y + height);
        }

        protected void Point(double x, double y)
        {
            Point(x,y,0.0);
        }

        protected void Point(double x, double y, double z)
        {
            Sxy(ref x, ref y);
            GL.Color4(Fill);

            GL.Begin(BeginMode.Points);
            {
                GL.Vertex3(x,y,z);
            }
            GL.End();
        }

        protected void Line(double x1, double y1, double x2, double y2)
        {
            Line(x1,y1,0.0,x2,y2,0.0);
        }

        protected void Line(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Sxy(ref x1, ref y1);
            Sxy(ref x2, ref y2);
            GL.Color4(Stroke);

            GL.Begin(BeginMode.Lines);
            {
                GL.Vertex3(x1,y1,z1);
                GL.Vertex3(x2,y2,z2);
            }
            GL.End();
        }

        protected void Quad(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            Sxy(ref x1, ref y1);
            Sxy(ref x2, ref y2);
            Sxy(ref x3, ref y3);
            Sxy(ref x4, ref y4);
            
            GL.Color4(Fill);
            GL.Begin(BeginMode.Quads);
            {
                GL.Vertex2(x1, y1);
                GL.Vertex2(x2, y2);
                GL.Vertex2(x3, y3);
                GL.Vertex2(x4, y4);
            }
            GL.End();

            GL.Color4(Stroke);
            GL.Begin(BeginMode.LineLoop);
            {
                GL.Vertex2(x1,y1);
                GL.Vertex2(x2,y2);
                GL.Vertex2(x3,y3);
                GL.Vertex2(x4,y4);
            }
            GL.End();
        }

        protected void Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Sxy(ref x1, ref y1);
            Sxy(ref x2, ref y2);
            Sxy(ref x3, ref y3);

            GL.Color4(Fill);
            GL.Begin(BeginMode.Triangles);
            {
                GL.Vertex2(x1, y1);
                GL.Vertex2(x2, y2);
                GL.Vertex2(x3, y3);
            }
            GL.End();

            GL.Color4(Stroke);
            GL.Begin(BeginMode.LineLoop);
            {
                GL.Vertex2(x1, y1);
                GL.Vertex2(x2, y2);
                GL.Vertex2(x3, y3);
            }
            GL.End();
        }

        protected void Ellipse(double x, double y, double width, double height)
        {
            Sxy(ref x, ref y);
            Swh(ref width, ref height);

            GL.Color4(Fill);
            GL.Begin(BeginMode.Polygon);
            {
                ArcDrawVerticies(x, y, width, height, 0, TwoPI);
            }
            GL.End();

            GL.Color4(Stroke);
            GL.Begin(BeginMode.LineLoop);
            {
                ArcDrawVerticies(x, y, width, height, 0, TwoPI);
            }
            GL.End();
        }

        protected void Arc(double x, double y, double width, double height, double start, double end)
        {
            Sxy(ref x, ref y);
            Swh(ref width, ref height);

            GL.Color4(Stroke);
            GL.Begin(BeginMode.LineStrip);
            {
                ArcDrawVerticies(x, y, width, height, start, end);
            }
            GL.End();
        }

        private void ArcDrawVerticies(double sx, double sy, double swidth, double sheight, double start, double end)
        {
            double step = 1.0 / Math.Min(Width,Height) / Math.Max(Math.Abs(swidth), Math.Abs(sheight));
            for (double ang = start; ang < end; ang += step)
                GL.Vertex2(sx + swidth*Math.Cos(ang),sy + sheight*Math.Sin(ang));
        }

        protected enum ShapeMode
        {
            Polygon, Points, Lines, Triangles, TriangleStrip, TriangleFan, Quads, QuadStrip
        }

        private List<PVector> verticies = new List<PVector>();
        private BeginMode? beginMode = null;

        protected void BeginShape(ShapeMode mode = ShapeMode.Polygon)
        {
            beginMode = (BeginMode) Enum.Parse(typeof (BeginMode), mode.ToString());

            verticies.Clear();
        }

        protected void Vertex(double x, double y)
        {
            Sxy(ref x,ref y);

            verticies.Add(new PVector(x, y));
        }

        protected void EndShape()
        {
            if (beginMode == null)
                throw new ProcessingException("Call BeginShape() before EndShape()");
            
            // BUG: Fill correct colour to use for Lines and Points?
            GL.Color4(Fill);
            GL.Begin((BeginMode)beginMode);
            {
                foreach (var v in verticies)
                    GL.Vertex2(v.X, v.Y);
            }
            GL.End();

            if (!beginMode.AnyOf(BeginMode.Lines, BeginMode.Points))
            {
                GL.Color4(Stroke);
                GL.Begin(BeginMode.LineLoop);
                {
                    foreach (var v in verticies)
                        GL.Vertex2(v.X, v.Y);
                }
                GL.End();
            }

            beginMode = null;
        }
    }
}
