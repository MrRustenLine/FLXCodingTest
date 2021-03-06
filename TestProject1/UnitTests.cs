using FLXCodingTest;

namespace TestProject1
{
    public class Tests
    {
        int licencesActual = 0;
        int licencesExpected = 0;
        string dataFile = "";
        LicenceChecker licenceChecker;
        SearchParameters searchParams;
        string rootDir, newRootDir;

        [Test]
        public void Setup()
        {
            rootDir = System.IO.Directory.GetCurrentDirectory();
            newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
        }

        [Test]
        public void Test1()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest1DataFile.csv");
            searchParams = new SearchParameters(dataFile, "374");
            licenceChecker = new LicenceChecker(searchParams);
            licencesActual = licenceChecker.CheckLicences();
            licencesExpected = 1;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test2()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest2DataFile.csv");
            searchParams = new SearchParameters(dataFile, "374");
            licenceChecker = new LicenceChecker(searchParams);
            licencesActual = licenceChecker.CheckLicences();
            licencesExpected = 3;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

        [Test]
        public void Test3()
        {
            dataFile = Path.Combine(newRootDir, "UnitTest3DataFile.csv");
            searchParams = new SearchParameters(dataFile, "374");
            licenceChecker = new LicenceChecker(searchParams);
            licencesActual = licenceChecker.CheckLicences();
            licencesExpected = 2;
            Assert.That(actual: licencesActual, Is.EqualTo(expected: licencesExpected));
        }

    }
}