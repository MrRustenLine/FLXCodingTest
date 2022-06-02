using FlexeraCodingTest;

namespace TestProject1
{
    public class Tests
    {
        //public void Setup()
        //{
        //}

        [Test]
        public void Test1()
        {
            int licencesActual = 0;
            string dataFile = "";
            LicenceChecker licenceChecker = new LicenceChecker();
            string rootDir = System.IO.Directory.GetCurrentDirectory();
            string newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
            dataFile = Path.Combine(newRootDir, "UnitTest1DataFile.csv");
            licencesActual = licenceChecker.CheckNoOfLicences(dataFile, "374");
            int licencesExpected = 1;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test2()
        {
            int licencesActual = 0;
            string dataFile = "";
            LicenceChecker licenceChecker = new LicenceChecker();
            string rootDir = System.IO.Directory.GetCurrentDirectory();
            string newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
            dataFile = Path.Combine(newRootDir, "UnitTest2DataFile.csv");
            licencesActual = licenceChecker.CheckNoOfLicences(dataFile, "374");
            int licencesExpected = 3;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test3()
        {
            int licencesActual = 0;
            string dataFile = "";
            LicenceChecker licenceChecker = new LicenceChecker();
            string rootDir = System.IO.Directory.GetCurrentDirectory();
            string newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
            dataFile = Path.Combine(newRootDir, "UnitTest3DataFile.csv");
            licencesActual = licenceChecker.CheckNoOfLicences(dataFile, "374");
            int licencesExpected = 2;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }
    }
}