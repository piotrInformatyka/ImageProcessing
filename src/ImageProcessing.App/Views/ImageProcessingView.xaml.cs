using ImageProcessing.App.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessing.App.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ImageProcessingView.xaml
    /// </summary>
    public partial class ImageProcessingView : UserControl
    {
        public ImageProcessingView()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var program = DataContext as ImageProcessingViewModel;
            program.OpenFile();
        }

        private void AsyncProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            var program = DataContext as ImageProcessingViewModel;
            program.ParallelImageProcessing();
        }

        private void SyncProcessingButton_Click(object sender, RoutedEventArgs e)
        {
            var program = DataContext as ImageProcessingViewModel;
            program.SynchronousImageProcessing();
        }
    }
}
