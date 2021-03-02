using ImageProcessing.App.Services;
using ImageProcessing.App.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Tests
{
    class ImageProcessingViewModelTests
    {
        [Test]
        public void openFile_should_setSelectedPath()
        {
            string expected = "path";
            Mock<IFileOpener> mock = new Mock<IFileOpener>();
            mock.Setup(x => x.OpenImageDialog()).Returns(expected);
            ImageProcessingViewModel target = new ImageProcessingViewModel(mock.Object);

            var exception = Assert.Throws<UriFormatException>(() => target.OpenFile());

            Assert.True(expected == target.SelectedPath);
        }
        [Test]
        public void providingIncorrectPath_should_Fail()
        {
            Mock<IFileOpener> mock = new Mock<IFileOpener>();
            ImageProcessingViewModel target = new ImageProcessingViewModel(mock.Object);

            var exception = Assert.Throws<Exception>(() => target.OpenFile());

            Assert.NotNull(exception);
            Assert.IsTrue(exception.Message.Equals("Invalid file format or path"));
        }
    }
}
