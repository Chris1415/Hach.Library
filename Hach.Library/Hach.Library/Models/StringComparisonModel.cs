using System;
using System.Collections.Generic;

namespace Hach.Library.Models
{
    /// <summary>
    /// Model to store information about markup changes
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    [Serializable]
    public class StringComparisonModel
    {
        /// <summary>
        /// Reference Markup
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Stores a List of all PArts which have been changed
        /// </summary>
        public IList<MatchModel> Changes { get; set; }

        /// <summary>
        /// Changed Positions in markup
        /// </summary>
        public IList<IList<int>> ChangedPositions { get; set; }

        /// <summary>
        /// Flag to determine if the string is diffrent
        /// </summary>
        public bool IsStringDiffrent { get; set; }
    }
}