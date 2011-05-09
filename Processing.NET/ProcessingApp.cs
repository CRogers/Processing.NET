﻿using System.Drawing;
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
            Background(Color.Crimson);
        }

        protected virtual void Setup()
        {
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



        protected void Background(Color c)
        {
            background = c;
            GL.ClearColor(c);
            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        protected void Rect(float x, float y, float width, float height)
        {
            GL.Color4(Fill);

            GL.Begin(BeginMode.LineLoop);
            {
                GL.Vertex2(x,y);
                GL.Vertex2(x+width,y);
                GL.Vertex2(x+width,y+height);
                GL.Vertex2(x,y+height);
            }
            GL.End();
        }
    }
}
