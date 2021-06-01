using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CandidateNames.Sources;

namespace CandidateNames.Candidate
{
    public class Candidates: UserRepository
    {
        public List<string> CombineAllApplicants(List<string> allDevelopers, List<string> allTesters)
        {

            if (allDevelopers == null || allTesters == null)
            {
                throw new NullReferenceException();

            }
            return allDevelopers.Union(allTesters).ToList();
        }
    }
}
