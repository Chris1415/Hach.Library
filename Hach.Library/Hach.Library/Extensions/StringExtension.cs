namespace Hach.Library.Extensions
{
    /// <summary>
    /// String Extensions
    /// </summary>
    /// <author>
    /// Christian Hahn, Jun-2016
    /// </author>
    public static class StringExtension
    {
        /// <summary>
        /// Is Null or Empty Helper
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>true if the input string is null or empty</returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return input == null || input.Equals(string.Empty);
        }
    }
}
