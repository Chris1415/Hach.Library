using Hach.Library.Enums;
using Hach.Library.Services.Comparer.Text;

namespace Hach.Library.Factories
{
    /// <summary>
    /// Interface of the string comparer Factory
    /// </summary>
    /// <author>
    /// Christian Hahn - Dez 2016
    /// </author>
    public interface IStringComparerFactory
    {
        /// <summary>
        /// Creates an instance of the String comparer based on the given type
        /// </summary>
        /// <param name="type">given type</param>
        /// <returns>instance of string comparer</returns>
        IStringComparerService CreateStringComparerService(StringCompareTypes type);
    }
}
