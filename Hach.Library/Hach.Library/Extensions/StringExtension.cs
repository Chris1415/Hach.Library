using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Hach.Library.Models;
using Hach.Library.Services.Comparer.Text;
using Hach.Library.Services.Comparer.Text.Implementation;
using Hach.Library.Enums;
using Hach.Library.Factories;
using Hach.Library.Factories.Implementations;

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

        /// <summary>
        /// Encodes a given strin to UTF 8
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>UTF 8 encoded string</returns>
        public static string ToUtf8(this string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Extension to extract a host from a string in uri format
        /// </summary>
        /// <param name="input">string in uri format</param>
        /// <returns>host of string in uri format</returns>
        public static string HostOfUrl(this string input)
        {
            try
            {
                Uri interfaceUrlAsUri = new Uri(input);
                return interfaceUrlAsUri.Host;
            }
            catch (Exception)
            {
                return string.Empty;
            }          
        }

        /// <summary>
        /// Helper to compare to strings
        /// </summary>
        /// <param name="input">first string</param>
        /// <param name="toCompare">second string</param>
        /// <param name="comparisonType">Comparison Type</param>
        /// <returns>String comparison model to store the second string and all posions, which are diffrent</returns>
        public static StringComparisonModel Compare(this string input, string toCompare, StringCompareTypes comparisonType = StringCompareTypes.ExactMatch)
        {
            IStringComparerFactory ImageCompareFactory = new StringComparerFactory();

            if (input.IsNullOrEmpty() || toCompare.IsNullOrEmpty())
            {
                return new StringComparisonModel();
            }

            IStringComparerService comparer = ImageCompareFactory.CreateStringComparerService(comparisonType);
            return comparer.CompareStrings(input, toCompare);
        }

        /// <summary>
        /// Build a SHA 256 from a String
        /// </summary>
        /// <param name="text">input string</param>
        /// <returns>SHA 256</returns>
        public static string Sha256(this string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            return hash.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        }
    }
}
