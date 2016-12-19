using Hach.Library.Enums;
using Hach.Library.Services.Comparer.Image;

namespace Hach.Library.Factories
{
    /// <summary>
    /// Interface of the image comparer Factory
    /// </summary>
    /// <author>
    /// Christian Hahn - Dez 2016
    /// </author>
    public interface IImageComparerFactory
    {
        /// <summary>
        /// Creates an instance of the String comparer based on the given type
        /// </summary>
        /// <param name="type">given type</param>
        /// <returns>instance of string comparer</returns>
        IImageCompareService CreateStringComparerService(ImageComparerTypes type);
    }
}
