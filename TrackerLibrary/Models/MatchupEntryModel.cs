using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    class MatchupEntryModel
    {
        public TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        public MatchupModel ParentMatchup { get; set; }

    }
}
