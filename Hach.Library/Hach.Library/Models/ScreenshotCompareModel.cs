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

        #region c'tor

        /// <summary>
        /// Default c'tor
        /// </summary>
        public ScreenshotCompareModel()
        {
        }

        /// <summary>
        /// Copy c'tor
        /// </summary>
        /// <param name="model"></param>
        public ScreenshotCompareModel(ScreenshotCompareModel model)
        {
            DiffrenceScreenshot = model.DiffrenceScreenshot;
            IsScreenshotDiffrent = model.IsScreenshotDiffrent;
        }

        #endregion
    }
}
