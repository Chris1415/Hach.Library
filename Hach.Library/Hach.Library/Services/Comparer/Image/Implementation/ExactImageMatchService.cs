using System.Drawing;
using Hach.Library.Extensions;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Image.Implementation
{
    public class ExactImageMatchService : IImageCompareService
    {
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
