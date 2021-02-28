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

namespace ImageProcessing.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new bitmap.

            Bitmap bmp = new Bitmap("E:\\test\\sample\\car.jpg");

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0 , bmpData.Height, i=>
               {
                   for(int j = 0; j < bmpData.Width; j += 1)
                   {
                       var counter = ((i * bmpData.Width) + j) * 3 + 1;
                    
                        if (rgbValues[counter] > rgbValues[counter - 1])
                        {
                            if (rgbValues[counter] > rgbValues[counter + 1])
                            {
                                rgbValues[counter] = 255;
                                rgbValues[counter - 1] = 0;
                                rgbValues[counter + 1] = 0;
                            }
                            else
                            {
                                rgbValues[counter] = 0;
                                rgbValues[counter - 1] = 0;
                                rgbValues[counter + 1] = 255;
                            }
                        }
                        else
                        {
                            if (rgbValues[counter] > rgbValues[counter - 1])
                            {
                                rgbValues[counter] = 255;
                                rgbValues[counter - 1] = 0;
                                rgbValues[counter + 1] = 0;
                            }
                            else
                            {
                                rgbValues[counter] = 0;
                                rgbValues[counter - 1] = 255;
                                rgbValues[counter + 1] = 0;
                            }
                        }

                    }
                }
            );
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = ts.Milliseconds.ToString();
            Console.WriteLine("RunTime " + elapsedTime);

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            bmp.Save(Path.Combine(@"E:\test\modified", "lenabmp.bmp"));
            Console.ReadLine();
        }
        public static void Process(byte[] rgbValues, int x, int y, int endx, int endy, int width, int depth)
        {
            for (int i = x; i < endx; i++)
            {
                for (int j = y; j < endy; j++)
                {
                    var counter = ((j * width) + i) * depth + 1;
                    if (rgbValues[counter] > rgbValues[counter - 1])
                    {
                        if (rgbValues[counter] > rgbValues[counter + 1])
                        {
                            rgbValues[counter] = 255;
                            rgbValues[counter - 1] = 0;
                            rgbValues[counter + 1] = 0;
                        }
                        else
                        {
                            rgbValues[counter] = 0;
                            rgbValues[counter - 1] = 0;
                            rgbValues[counter + 1] = 255;
                        }
                    }
                    else
                    {
                        if (rgbValues[counter] > rgbValues[counter - 1])
                        {
                            rgbValues[counter] = 255;
                            rgbValues[counter - 1] = 0;
                            rgbValues[counter + 1] = 0;
                        }
                        else
                        {
                            rgbValues[counter] = 0;
                            rgbValues[counter - 1] = 255;
                            rgbValues[counter + 1] = 0;
                        }
                    }

                    }
                }
        }
    }
}
