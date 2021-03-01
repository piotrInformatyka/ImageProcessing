using ImageProcessing.App.Models;
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
        private string _defaultPath;
        public ImageProcessingModel ImageProcessing { get; set; }
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; OnPropertyChanged("SelectedPath"); }
        }
        public ImageProcessingViewModel()
        {
            _defaultPath = "c:\\";
            ImageProcessing = new ImageProcessingModel();
        }
        public void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = _defaultPath,
                Filter = "Image files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files(*.*)|*.*",
                RestoreDirectory = true
            };
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                SelectedPath = selectedFileName;
                ImageProcessing.LoadImage(selectedFileName);
            }
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
