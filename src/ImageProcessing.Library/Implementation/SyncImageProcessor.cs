using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Library.Implementation
{
    public class SyncImageProcessor : ImageProcessor
    {
        protected override void kernel()
        {
            for (int counter = 1; counter < rgbValues.Length - 3; counter += 3)
            {
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
        }
    }
}

