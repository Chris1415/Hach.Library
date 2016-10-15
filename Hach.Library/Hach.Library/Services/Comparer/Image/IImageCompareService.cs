using System.Drawing;
using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Image
{
    public interface IImageCompareService
    {
        ScreenshotCompareModel CompareImage(Bitmap first, Bitmap second);
    }
}
