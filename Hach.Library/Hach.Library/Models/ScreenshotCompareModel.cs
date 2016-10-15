using System;
using System.Drawing;

namespace Hach.Library.Models
{
    /// <summary>
    /// Model to store information about screenshot and diffrence
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    [Serializable]
    public class ScreenshotCompareModel
    {
        /// <summary>
        /// Screenshot with the highlighted diffrence
        /// </summary>
        public Bitmap DiffrenceScreenshot { get; set; }

        /// <summary>
        /// Flag to determine if the screenshot is diffrent
        /// </summary>
        public bool IsScreenshotDiffrent { get; set; }
    }
}
