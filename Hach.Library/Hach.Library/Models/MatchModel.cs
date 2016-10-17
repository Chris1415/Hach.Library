﻿using System;

namespace Hach.Library.Models
{
    /// <summary>
    /// The Match Model
    /// </summary>
    /// <author>
    /// Christian Hahn, Okt-2016
    /// </author>
    public class MatchModel
    {
        /// <summary>
        /// Match
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// Type of Match
        /// </summary>
        public MatchTypes MatchType { get; set; }

        /// <summary>
        /// Bounds of the match
        /// </summary>
        public Tuple<int,int> Bounds { get; set; }
    }
}
