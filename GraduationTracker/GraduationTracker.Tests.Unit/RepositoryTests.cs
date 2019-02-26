using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetStudentsTest()
        {
            var result = Repository.GetStudent(1);
            var course = result.Courses.First();

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, course.Id);
            Assert.AreEqual("Math", course.Name);
            Assert.AreEqual(95, course.Mark);
        }

        [TestMethod]
        public void GetDiplomaTest()
        {
            var result = Repository.GetDiploma(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(4, result.Credits);
            Assert.AreEqual(100, result.Requirements.First());
        }

        [TestMethod]
        public void GetRequirementTest()
        {
            var result = Repository.GetRequirement(102);

            Assert.AreEqual(102, result.Id);
            Assert.AreEqual("Science", result.Name);
            Assert.AreEqual(1, result.Credits);
            Assert.AreEqual(50, result.MinimumMark);
            Assert.AreEqual(2, result.Courses.First());
        }

        [TestMethod]
        public void GetGetRequirementsTest()
        {
            var requirements = Repository.GetRequirements();
            var result = requirements.ElementAt(2);

            Assert.AreEqual(103, result.Id);
            Assert.AreEqual("Literature", result.Name);
            Assert.AreEqual(1, result.Credits);
            Assert.AreEqual(50, result.MinimumMark);
            Assert.AreEqual(3, result.Courses.First());
        }
    }
}
