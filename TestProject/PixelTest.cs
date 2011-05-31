using System;
using System.Drawing;
using Processing.NET;

namespace TestProject
{
    class PixelTest : ProcessingApp
    {
        protected override void Draw()
        {
            Background(Color.White);
            LoadPixels();

            for(int i = 0; i < pixels.Length; i++)
            {
                var c = pixels[i];
                pixels[i] = Color.FromArgb((byte)(Math.Abs(MouseX-i%Height) * 255) / Width, (byte)(Math.Abs(MouseY-i/Height) * 255) / Height, 0);
            }

            UpdatePixels();
        }
    }
}
