using ImageProcessing.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ImageProcessing.App.Extensions;

namespace ImageProcessing.App.Models
{
    public class ImageProcessingModel : ObservableObject
    {
        private IImageProcessing _imageProcessing;
        public BitmapImage OriginalImage { get; set; }
        public BitmapImage ModifiedImage { get; set; }
        public string AsynchronousTime { get; set; }
        public string SynchronousTime { get; set; }

        public ImageProcessingModel(IImageProcessing imageProcessing)
        {
            _imageProcessing = imageProcessing;
            ResetTextLabels();
        }
        public void LoadImage(string path)
        {
            ResetTextLabels();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path);
            bitmap.EndInit();
            OriginalImage = bitmap;
            if (ModifiedImage != null)
            {
                ModifiedImage = null;
                OnPropertyChanged("ModifiedImage");
            }
            OnPropertyChanged("OriginalImage");
        }
        public void ParallelImageProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.ToMainColorsAsync(bmp);
                UpdateImage(result);
            }
        }
        public void SynchronousImageProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.ToMainColors(bmp);
                UpdateImage(result);
            }
        }
        public void GrayscaleImageProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.ToGrayscale(bmp);
                UpdateImage(result);
            }
        }
        public void EdgeDetectionProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.EdgeDetection(bmp);
                UpdateImage(result);
            }
        }
        private void ResetTextLabels()
        {
            AsynchronousTime = "Wykonaj operację";
            SynchronousTime = "Wykonaj operację";
            OnPropertyChanged("AsynchronousTime");
            OnPropertyChanged("SynchronousTime");
        }
        private void UpdateImage(ToMainColorsResult result)
        {
            ModifiedImage = result.Image.Bitmap2BitmapImage();
            SynchronousTime = result.Time.TotalMilliseconds.ToString() + " ms";
            OnPropertyChanged("ModifiedImage");
            OnPropertyChanged("SynchronousTime");
        }

    }
}
