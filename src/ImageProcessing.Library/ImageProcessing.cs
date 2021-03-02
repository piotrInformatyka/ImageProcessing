using ImageProcessing.Library.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageProcessing.Library
{
    public class ImageProcessing : IImageProcessing
    {
        Stopwatch _stopwatch;
        public ImageProcessing()
        {
            _stopwatch = new Stopwatch();
        }
        public ToMainColorsResult ToMainColors(Bitmap bmp)
        {
            _stopwatch.Start();

            ImageProcessor imageProcessor = new SyncImageProcessor();
            var image = imageProcessor.ToMainColor(bmp);

            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return new ToMainColorsResult
            {
                Image = image,
                Time = ts
            };
        }
        
        public ToMainColorsResult ToMainColorsAsync(Bitmap bmp)
        {
            //It is not asynchronous method just it uses parallelism in image processing

            _stopwatch.Start();

            ImageProcessor imageProcessor = new ParallelImageProcessor();
            var image = imageProcessor.ToMainColor(bmp);

            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return new ToMainColorsResult
            {
                Image = image,
                Time = ts
            };
        }
        public ToMainColorsResult ToGrayscale (Bitmap bmp)
        {
            _stopwatch.Start();

            ImageProcessor imageProcessor = new SyncGrayscaleProcessor();
            var image = imageProcessor.ToMainColor(bmp);

            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return new ToMainColorsResult
            {
                Image = image,
                Time = ts
            };
        }
        public ToMainColorsResult EdgeDetection(Bitmap bmp)
        {
            _stopwatch.Start();

            ImageProcessor imageProcessor = new SyncGrayscaleProcessor();
            var image = imageProcessor.ToMainColor(bmp);
            imageProcessor = new SyncEdgeDetection();
            image = imageProcessor.ToMainColor(image);

            _stopwatch.Stop();
            TimeSpan ts = _stopwatch.Elapsed;
            _stopwatch.Reset();
            return new ToMainColorsResult
            {
                Image = image,
                Time = ts
            };
        }
    }
}
