using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CandidateNames.Candidate;
using NUnit.Framework;

namespace CandidateNames.Tests
{
    [TestFixture]
    public class CandidatesTests
    {


        [Test]
        public void CombineAllApplicants_NullLists_ThrowsException()
        {
            var candidates = new Candidates();
            List<string> developers = null;
            List<string> testers = null;
            Assert.Throws<NullReferenceException>(() => { candidates.CombineAllApplicants(developers, testers); });
        }
        [Test]
        public void CombineAllApplicants_PassValidLists_ReturnListOfStrings()
        {
            var candidates = new Candidates();
            List<string> developers = candidates.GetDeveloperJobApplicants().ToList();
            List<string> testers = candidates.GetTesterJobApplicants().ToList();
            Assert.That(candidates.CombineAllApplicants(developers, testers), Is.TypeOf<List<string>>());
        }
        [Test]
        public void CombineAllApplicants_SameNameInTwoLists_ReturnUniqueName()
        {
            var candidates = new Candidates();
            List<string> developers = new List<string>();
            developers.Add("Gherca, Andreea");
            developers.Add("Trillo, Alex");

            List<string> testers = new List<string>();
            testers.Add("Gherca, Andreea");

            Assert.That(candidates.CombineAllApplicants(developers, testers).Count(p => p == "Gherca, Andreea"), Is.EqualTo(1));
        }

        [Test]
        [TestCase("Antonio, Mchaney")]
        [TestCase("Mollie, Rabinowitz")]
        public void IsValidName_PassValidName_ReturnTrue(string name)
        {
            var candidates = new Candidates();
            bool result = candidates.IsaValidName(name);

            Assert.That(true, Is.EqualTo(result));
        }
        [Test]
        [TestCase("Rebecca")]
        [TestCase("Long ,,Pigford")]
        [TestCase("Marceline ,Polley")]
        [TestCase("Gudrun&nbsp;&nbsp;  ,Caughman")]
        public void IsValidName_PassInvalidName_ReturnFalse(string name)
        {
            var candidates = new Candidates();
            bool result = candidates.IsaValidName(name);

            Assert.That(false, Is.EqualTo(result));
        }

        [Test]
        public void CleaningApplicantsList_OneValidName_ReturnsTheValidName()
        {
            var candidates = new Candidates();
            List<string> allApplicants = new List<string>();
            allApplicants.Add("Gherca, Andreea");

            List<string> result = new List<string>();
            result.Add("Gherca, Andreea");

            Assert.That(result, Is.EqualTo(candidates.CleaningApplicantsList(allApplicants)));
        }

        [Test]
        public void CleaningApplicantsList_OneValidAndOneInvalidName_ReturnsTheValidName()
        {
            var candidates = new Candidates();
            List<string> allApplicants = new List<string>();
            allApplicants.Add("Gherca,, Andreea");
            allApplicants.Add("Brown, John");

            Assert.That(candidates.CleaningApplicantsList(allApplicants).Count(p => p == "Gherca,, Andreea"), Is.EqualTo(0));
            Assert.That(candidates.CleaningApplicantsList(allApplicants).Any(p => p == "Brown, John"));
            Assert.That(true, Is.EqualTo(candidates.CleaningApplicantsList(allApplicants).Contains("Brown, John")));

        }

        [Test]
        public void LettersFrequency_PassTwoNamesStartingWithS_Returns2S()
        {
            var candidates = new Candidates();
            List<string> allApplicants = new List<string>();
            allApplicants.Add("Smith, Sally");
            allApplicants.Add("Ali, Sonia");
            Dictionary<string, int> expectedResult = new Dictionary<string, int>();
            expectedResult.Add("S", 2);

            var result = candidates.LettersFrequency(allApplicants);

            Assert.That(expectedResult, Is.EqualTo(result));

        }

    }
}
