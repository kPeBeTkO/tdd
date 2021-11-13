﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace TagsCloudVisualization
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var visualiser = new TagsCloudVisualiser(new Point());
            var random = new Random();
            var sizes = new List<Size>();
            for(var i = 0; i < 1000; i++)
            {
                var height = random.Next(1, 3);
                sizes.Add(new Size(random.Next(height, height * 5), height));
                //visualiser.PutRectangle(new Size(1,1));
            }
            var n = 0;
            foreach (var size in sizes.OrderByDescending(s => s.Width + s.Height))
            {
                visualiser.PutRectangle(size);
                Console.WriteLine(n++);
            }
            /*visualiser.PutRectangle(new Size(2, 2));
            visualiser.PutRectangle(new Size(6, 2));
            visualiser.PutRectangle(new Size(6, 2));
            visualiser.PutRectangle(new Size(2, 6));
            visualiser.PutRectangle(new Size(2, 6));
            visualiser.PutRectangle(new Size(2, 2));*/
            var image = visualiser.DrawCloud(new Size(1000, 1000));
            image.Save("testimage.png", ImageFormat.Png);
            Process.Start(new ProcessStartInfo(Directory.GetCurrentDirectory() + "\\testimage.png") { UseShellExecute = true });
        }
    }
}