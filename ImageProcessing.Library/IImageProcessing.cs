using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ImageProcessing.Library
{
    public interface IImageProcessing
    {
        ToMainColorsResult ToMainColors(Bitmap bmp);
        ToMainColorsResult ToMainColorsAsync(Bitmap bmp);
    }
}
