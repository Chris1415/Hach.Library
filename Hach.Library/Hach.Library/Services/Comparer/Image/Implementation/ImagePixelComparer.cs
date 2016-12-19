using System;
using System.Drawing;
using System.Drawing.Imaging;
using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Image.Implementation
{
    public class ImagePixelComparer : IImageCompareService
    {
        public ScreenshotCompareModel CompareImage(Bitmap first, Bitmap second)
        {
            bool hasChanged = false;
            Bitmap result = new Bitmap(second);
            for (int ii = 0; ii < second.Width; ii++)
            {
                for (int jj = 0; jj < second.Height; jj++)
                {
                    Color firstPixelColor;
                    try
                    {
                        firstPixelColor = first.GetPixel(ii, jj);
                    }
                    catch (Exception)
                    {
                        firstPixelColor = Color.Empty;
                    }

                    Color secondPixelColor = second.GetPixel(ii, jj);

                    if (firstPixelColor != secondPixelColor)
                    {
                        result.SetPixel(ii, jj, Color.Crimson);
                        hasChanged = true;
                    }
                }
            }

            return new ScreenshotCompareModel()
            {
                DiffrenceScreenshot = result.ToByteArray(ImageFormat.Jpeg),
                IsScreenshotDiffrent = hasChanged
            };
        }
    }
}
