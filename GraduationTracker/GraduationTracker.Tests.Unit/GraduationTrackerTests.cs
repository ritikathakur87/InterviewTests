using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly GraduationTracker _graduationTracker;
        private readonly Diploma _diploma;

        public GraduationTrackerTests()
        {
            _graduationTracker = new GraduationTracker();

            _diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new[] { 100, 102, 103, 104 }
            };
        }

        [TestMethod]
        public void HasGraduated_MagnaCumLaude_Test()
        {
            var student = new Student
            {
                Id = 1,
                Courses = new[]
                {
                    new Course {Id = 1, Name = "Math", Mark = 95},
                    new Course {Id = 2, Name = "Science", Mark = 95},
                    new Course {Id = 3, Name = "Literature", Mark = 95},
                    new Course {Id = 4, Name = "Physichal Education", Mark = 95}
                }
            };

            var result = _graduationTracker.HasGraduated(_diploma, student);

            Assert.IsTrue(result.Item1);
            Assert.AreEqual(STANDING.MagnaCumLaude, result.Item2);
        }

        [TestMethod]
        public void HasGraduated_Average_Test()
        {
            var student = new Student
            {
                Id = 3,
                Courses = new[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            };

            var result = _graduationTracker.HasGraduated(_diploma, student);

            Assert.IsTrue(result.Item1);
            Assert.AreEqual(STANDING.Average, result.Item2);
        }

        [TestMethod]
        public void HasGraduated_Remedial_Test()
        {
            var student = new Student
            {
                Id = 4,
                Courses = new[]
                {
                    new Course {Id = 1, Name = "Math", Mark = 40},
                    new Course {Id = 2, Name = "Science", Mark = 40},
                    new Course {Id = 3, Name = "Literature", Mark = 40},
                    new Course {Id = 4, Name = "Physichal Education", Mark = 40}
                }
            };

            var result = _graduationTracker.HasGraduated(_diploma, student);

            Assert.IsFalse(result.Item1);
            Assert.AreEqual(STANDING.Remedial, result.Item2);
        }
    }
}