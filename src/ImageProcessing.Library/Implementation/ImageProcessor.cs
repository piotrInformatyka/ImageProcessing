using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ImageProcessing.Library
{
    //ImageProcessor is abstract class in TemplateMethod for synchronous and parallel algorithms
    public abstract class ImageProcessor
    {
        protected BitmapData bmpData;
        protected byte[] rgbValues;
        protected int bytes;
        public Bitmap ToMainColor(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                    PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;

            bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            //Parallel or synchronous image processing
            kernel();

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(bmpData);

            return bmp;
        }
        protected abstract void kernel();
    }
}
