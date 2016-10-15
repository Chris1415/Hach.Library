using System;
using System.Drawing;
using System.IO;

namespace Hach.Library.Extensions
{
    /// <summary>
    /// Byte Extension
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public static class ByteExtension
    {
        /// <summary>
        /// Converts a byte array into an image
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>Bitmap</returns>
        public static Bitmap ToBitmap(this byte[] input)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(input))
                {
                    return new Bitmap(ms);
                }
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
