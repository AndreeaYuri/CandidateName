using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateWeb.Models
{
    public class CandidateViewModel
    {

        public List<string> Developers { get; set; }
        public List<string> Testers { get; set; }
        public List<string> AllCandidates { get; set; }
        public List<string> AllCleanedCandidates { get; set; }
        public Dictionary<string, int> FrequencyLetters { get; set; }
    }
}
