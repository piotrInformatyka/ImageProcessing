using ImageProcessing.App.Models;
using ImageProcessing.Library;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Tests
{
    class ImageProcessingModelTests
    {
        [Test]
        public void loadImage_should_resetTimeProperties()
        {
            Mock<IImageProcessing> mock = new Mock<IImageProcessing>();
            ImageProcessingModel target = new ImageProcessingModel(mock.Object);
            target.AsynchronousTime = "test";
            string expected = "Wykonaj operację";

            var exception = Assert.Throws<UriFormatException>(() => target.LoadImage("path"));

            Assert.True(expected == target.AsynchronousTime);
        }
    }
}
