using ImageProcessing.App.Models;
using ImageProcessing.App.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ImageProcessing.App.ViewModels
{
   public class ImageProcessingViewModel : ObservableObject
    {
        private string _selectedPath;
        private IFileOpener _fileOpener;
        public ImageProcessingModel ImageProcessing { get; set; }
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; OnPropertyChanged("SelectedPath"); }
        }
        public ImageProcessingViewModel(IFileOpener fileOpener)
        {
            ImageProcessing = new ImageProcessingModel(new Library.ImageProcessing());
            _fileOpener = fileOpener;
        }
        public void OpenFile()
        {
            string filePath = _fileOpener.OpenImageDialog();
            if (!String.IsNullOrEmpty(filePath))
            {
                SelectedPath = filePath;
                ImageProcessing.LoadImage(filePath);
            }
            else
                throw new Exception("Invalid file format or path");
        }
        public void ParallelImageProcessing()
        {
            ImageProcessing.ParallelImageProcessing();
        }
        public void SynchronousImageProcessing()
        {
            ImageProcessing.SynchronousImageProcessing();
        }
    }
}
