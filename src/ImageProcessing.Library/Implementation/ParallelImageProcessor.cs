using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Library.Implementation
{
    public class ParallelImageProcessor : ImageProcessor
    {
        protected override void kernel()
        {
            Parallel.For(0, bmpData.Height, i =>
            {
                for (int j = 0; j < bmpData.Width; j += 1)
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
                    else if (rgbValues[counter] > rgbValues[counter - 1])
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
            });
        }
    }
}
