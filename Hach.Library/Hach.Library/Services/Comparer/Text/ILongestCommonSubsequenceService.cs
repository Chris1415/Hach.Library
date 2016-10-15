using Hach.Library.Models;

namespace Hach.Library.Services.Comparer.Text
{
    /// <summary>
    /// Longest Common Subsequence Service to determine diffrences between two strings
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public interface ILongestCommonSubsequenceService : IStringComparerService
    {
        /// <summary>
        /// Calculates the Lcs Matrix of two given strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>Lcs Matrix</returns>
        int[,] CalculateLcsMatrix(string first, string second);

        /// <summary>
        /// Builds the string comparison model, based on the given strings and the Lcs matrix
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <param name="lcsMatrix">lcs matrix</param>
        /// <returns>string comparison model</returns>
        StringComparisonModel BuildStringComparisonModel(string first, string second, int[,] lcsMatrix);

        /// <summary>
        /// Builds the string comparison model, based on the given strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>string comparison model</returns>
        StringComparisonModel BuildStringComparisonModel(string first, string second);
    }
}
