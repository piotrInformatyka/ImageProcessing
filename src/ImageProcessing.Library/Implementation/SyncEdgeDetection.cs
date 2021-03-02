using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Library.Implementation
{
    public class SyncEdgeDetection : ImageProcessor
    {
        protected override void kernel()
        {
            int height = bmpData.Height;
            int width = bmpData.Width;
            var outputVector = new byte[bytes];
            int [,] Gx = new int[,] {  { -1, 0, 1}, { -2, 0, 2}, { -1, 0, 1} };
            int [,] Gy = new int [,] {{ -1, -2, -1}, { 0, 0, 0}, { 1, 2, 1} };
            int S1 = 0;
            int S2 = 0;
            for(int i = 1; i < height -1 ; i++)
            {
                for(int j = 1; j < width - 1; j++)
                {
                    //var index = ((j * width) + i)*3;
                    // Dummy work    
                    // To grayscale (0.2126 R + 0.7152 G + 0.0722 B)
                    //var b = 0.2126 * rgbValues[offset + 0] + 0.7152 * rgbValues[offset + 1] + 0.0722 * rgbValues[offset + 2];
                    //rgbValues[offset + 0] = rgbValues[offset + 1] = rgbValues[offset + 2] = (byte)b;
                    for(int k = 0; k < 3; k++)
                    {
                        for(int l = 0; l < 3; l++)
                        {
                            int offset = ((i + k - 1) * width + j + l - 1) * 3;
                            int x = Gx[k, l] * (rgbValues[offset] + rgbValues[offset + 1] + rgbValues[offset + 2]);
                            int y = Gx[k, l] * (rgbValues[offset] + rgbValues[offset + 1] + rgbValues[offset + 2]);
                            S1 += x;
                            S2 += y;
                        }
                    }
                    int index = (i * width + j) * 3;
                    int value = (int)Math.Sqrt(Math.Pow(S1, 2) + Math.Pow(S2, 2));
                    if (value > 255)
                        value = 255;
                    outputVector[index] = outputVector[index + 1] = outputVector[index + 2] = (byte)value;
                    S1 = 0;
                    S2 = 0;
                }
            }
            rgbValues = outputVector;

        }
    }
}
