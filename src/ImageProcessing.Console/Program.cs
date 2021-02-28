using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing.Imaging;
using ImageProcessing.Library;

namespace ImageProcessing.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap("E:\\test\\sample\\car.jpg");
            IImageProcessing imageProcessing = new Library.ImageProcessing();
            var x = imageProcessing.ToMainColorsAsync(bmp);
            x.Image.Save(Path.Combine(@"E:\test\modified", "lenabmp.bmp"));
            Console.WriteLine(x.Time.Milliseconds.ToString());
            Console.ReadLine();
        }
    }
}
