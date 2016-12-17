using Hach.Library.Enums;
using Hach.Library.Services.Comparer.Image;
using Hach.Library.Services.Comparer.Image.Implementation;

namespace Hach.Library.Factories.Implementations
{
    /// <summary>
    /// Image Comparer Service Factory
    /// </summary>
    /// <author>
    /// Christian Hahn - Dez 2016
    /// </author>
    class ImageComparerFactory : IImageComparerFactory
    {
        /// <summary>
        /// Creates an instance of the String comparer based on the given type
        /// </summary>
        /// <param name="type">given type</param>
        /// <returns>instance of string comparer</returns>
        public IImageCompareService CreateStringComparerService(ImageComparerTypes type)
        {
            switch (type)
            {
                case ImageComparerTypes.ExactImageMatch:
                    return new ExactImageMatchService();
                case ImageComparerTypes.ImagePixelComparer:
                    return new ImagePixelComparer();
                default:
                    return new ExactImageMatchService();
            }
        }
    }
}
