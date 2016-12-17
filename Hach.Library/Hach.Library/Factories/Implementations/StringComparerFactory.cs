using Hach.Library.Enums;
using Hach.Library.Services.Comparer.Text;
using Hach.Library.Services.Comparer.Text.Implementation;

namespace Hach.Library.Factories.Implementations
{
    /// <summary>
    /// String comparer Service factory
    /// </summary>
    /// <author>
    /// Christian Hahn - Dez 2016
    /// </author>
    public class StringComparerFactory : IStringComparerFactory
    {
        /// <summary>
        /// Creates an instance of the String comparer based on the given type
        /// </summary>
        /// <param name="type">given type</param>
        /// <returns>instance of string comparer</returns>
        public IStringComparerService CreateStringComparerService(StringCompareTypes type)
        {
            switch (type)
            {
                case StringCompareTypes.ExactMatch:
                    return new ExactMatchService();
                case StringCompareTypes.HtmlDiff:
                    return new HtmlDiffService();
                case StringCompareTypes.LCS:
                    return new LongestCommonSubsequenceService();
                default:
                    return new ExactMatchService();
            }
        }
    }
}
