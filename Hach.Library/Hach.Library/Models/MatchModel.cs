using System;

namespace Hach.Library.Models
{
    public class MatchModel
    {
        public string Match { get; set; }

        public MatchTypes MatchType { get; set; }

        public Tuple<int,int> Bounds { get; set; }
    }
}
