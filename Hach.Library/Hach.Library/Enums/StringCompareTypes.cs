namespace Hach.Library.Enums
{
    /// <summary>
    /// Types of String comparer
    /// </summary>
    /// <author>
    /// Christian Hahn - Dez 2016
    /// </author>
    public enum StringCompareTypes
    {
        /// <summary>
        /// Exact Match based on hash
        /// </summary>
        ExactMatch,

        /// <summary>
        /// String Comparer based on a 3rd Party software
        /// </summary>
        HtmlDiff,

        /// <summary>
        /// Longes Common Subsequent comparison
        /// </summary>
        LCS
    }
}
