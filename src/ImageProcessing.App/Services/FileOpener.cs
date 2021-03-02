using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.App.Services
{
    public class FileOpener : IFileOpener
    {
        string _defaultPath = "c:\\";
        public string OpenImageDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = _defaultPath,
                Filter = "Image files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files(*.*)|*.*",
                RestoreDirectory = true
            };
            if (dlg.ShowDialog() == true && ValidateFormat(dlg.FileName))
            {
                string selectedFileName = dlg.FileName;
                return selectedFileName;
            }
            return null;
        }
        private bool ValidateFormat(string fileName)
        {
            if (fileName.EndsWith(".jpg") || fileName.EndsWith(".bmp") || fileName.EndsWith(".png"))
                return true;
            return false;
        }
    }
}
