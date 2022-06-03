using FlexeraCodingTest;

namespace TestProject1
{
    public class Tests
    {
        int licencesActual = 0;
        int licencesExpected = 0;
        string dataFile = "";
        LicenceChecker licenceChecker;
        Query query;
        string rootDir, newRootDir;

        [Test]
        public void Setup()
        {
            licenceChecker = new LicenceChecker();
            query = new Query();
            rootDir = System.IO.Directory.GetCurrentDirectory();
            newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
            query.AppID = "374";
        }

        [Test]
        public void Test1()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest1DataFile.csv");
            query.DataFile = dataFile;
            licencesActual = licenceChecker.CheckNoOfLicences(query);
            licencesExpected = 1;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test2()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest2DataFile.csv");
            query.DataFile = dataFile;
            licencesActual = licenceChecker.CheckNoOfLicences(query);
            licencesExpected = 3;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test3()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest3DataFile.csv");
            query.DataFile = dataFile;
            licencesActual = licenceChecker.CheckNoOfLicences(query);
            licencesExpected = 2;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

    }
}