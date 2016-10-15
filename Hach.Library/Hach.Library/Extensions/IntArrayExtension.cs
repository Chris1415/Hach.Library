using System;
using System.Text;

namespace Hach.Library.Extensions
{
    /// <summary>
    /// int Array Extension
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public static class IntArrayExtension
    {
        /// <summary>
        /// To string method
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>string representation</returns>
        public static string ToArrayString(this int[,] input)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    sb.Append(input[i, j] + " ");
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
