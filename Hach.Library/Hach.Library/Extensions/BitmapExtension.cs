using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Hach.Library.Models;
using Hach.Library.Services.Comparer.Image;
using Hach.Library.Services.Comparer.Image.Implementation;

namespace Hach.Library.Extensions
{
    /// <summary>
    /// Bitmap Extension
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public static class BitmapExtension
    {
        /// <summary>
        /// Helper to calculate a Diff in two bitmaps
        /// </summary>
        /// <param name="first">first bitmap</param>
        /// <param name="second">second bitmap</param>
        /// <returns>Diff Bitmap based on the second one</returns>
        public static ScreenshotCompareModel Diff(this Bitmap first, Bitmap second)
        {
            IImageCompareService imageCompareService = new ExactImageMatchService();
            return imageCompareService.CompareImage(first, second);
        }

        /// <summary>
        /// Converts  aBitmap to Byte Array
        /// </summary>
        /// <param name="image">Bitmap</param>
        /// <param name="format">Format</param>
        /// <returns>ByteArray</returns>
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            if (image == null)
            {
                return new byte[0];
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, format);
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                return new byte[0];
            }
           
        }

        /// <summary>
        /// Build a SHA 256 from a bitmap
        /// </summary>
        /// <param name="image">input bitmap</param>
        /// <returns>SHA 256</returns>
        public static string Sha256(this Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            byte[] raw = converter.ConvertTo(image, typeof(byte[])) as byte[];
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(raw);
            return hash.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        }
    }
}
