using System.Drawing;
using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Image.Implementation
{
    /// <summary>
    /// Exact Match Service based on SHA of image
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class ExactImageMatchService : IImageCompareService
    {
        /// <summary>
        /// Compare image method
        /// </summary>
        /// <param name="first">first image</param>
        /// <param name="second">second image</param>
        /// <returns>screenshot compare model</returns>
        public ScreenshotCompareModel CompareImage(Bitmap first, Bitmap second)
        {
          return new ScreenshotCompareModel()
            {
                DiffrenceScreenshot = null,
                IsScreenshotDiffrent = !first.Sha256().Equals(second.Sha256())
            };
        }
    }
}
