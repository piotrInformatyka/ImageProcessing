using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Library.Implementation
{
    class SyncGrayscaleProcessor : ImageProcessor
    {
        protected override void kernel()
        {
            for (int counter = 1; counter < rgbValues.Length - 3; counter += 3)
            {
                var b = 0.2126 * rgbValues[counter + 0] + 0.7152 * rgbValues[counter + 1] + 0.0722 * rgbValues[counter + 2];
                rgbValues[counter + 0] = rgbValues[counter + 1] = rgbValues[counter + 2] = (byte)b;
            }
        }
    }
}
