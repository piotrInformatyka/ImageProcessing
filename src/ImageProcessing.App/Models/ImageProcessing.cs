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

        public ImageProcessingModel()
        {
            _imageProcessing = new Library.ImageProcessing();
            ResetTextLabels();
        }
        public void LoadImage(string path)
        {
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
            ResetTextLabels();
        }
        public void ParallelImageProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.ToMainColorsAsync(bmp);
                ModifiedImage = result.Image.Bitmap2BitmapImage();
                AsynchronousTime = result.Time.Milliseconds.ToString();
                OnPropertyChanged("ModifiedImage");
                OnPropertyChanged("AsynchronousTime");
            }
        }
        public void SynchronousImageProcessing()
        {
            if (OriginalImage != null)
            {
                var bmp = OriginalImage.BitmapImage2Bitmap();
                var result = _imageProcessing.ToMainColors(bmp);
                ModifiedImage = result.Image.Bitmap2BitmapImage();
                SynchronousTime = result.Time.Milliseconds.ToString();
                OnPropertyChanged("ModifiedImage");
                OnPropertyChanged("SynchronousTime");
            }
        }
        private void ResetTextLabels()
        {
            AsynchronousTime = "Wykonaj operację";
            SynchronousTime = "Wykonaj operację";
            OnPropertyChanged("AsynchronousTime");
            OnPropertyChanged("SynchronousTime");
        }

    }
}
