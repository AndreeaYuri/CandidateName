using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public bool IsaValidName(string name)
        {
            //the valid pattern for regex is : 
            //^ asserts position at start of a line
            //(..) group
            //$ asserts position at the end of a line
            //[a-zA-Z]  matches a single character in the range between a and z and between A and Z
            //[a-zA - Z]+ at least one appearance of any alphabetic character
            //[,] comma
            //[\s] whitespace
            //valid name: "Carrie, Kirker"
            string pattern = @"^([a-zA-Z]+[,][\s][a-zA-Z]+)$";
            Regex currencyRegex = new Regex(pattern);
            if (currencyRegex.IsMatch(name))
                return true;

            return false;
        }

        public List<string> CleaningApplicantsList(List<string> applicantsList)
        {
            if (applicantsList == null)
            {
                throw new NullReferenceException();

            }
            List<string> allStudClean = new List<string>();

            foreach (var applicant in applicantsList)
            {
                //if the student's name is valid add it to the clean list
                if (IsaValidName(applicant))
                    allStudClean.Add(applicant);
            }

            return allStudClean;

        }


    }

}
