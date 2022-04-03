/* Author: Rusten Line
 * Date: 27.3.22
 * Desc: The app is written as a sysadmin utility with a basic console interface.
 * Please note that all the values (ApplicationID, maximum No of licences) are hard coded. Obviously, in reality they should configurable.
 */

using FlexeraCodingTest;

int licences = 0;
string dataFile = "";
LicenceChecker licenceChecker = new LicenceChecker();
#if DEBUG
//Conduct unit tests below.
string rootDir = System.IO.Directory.GetCurrentDirectory();
string newRootDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
Console.WriteLine("Commencing unit test 1." + Environment.NewLine);
dataFile = Path.Combine(newRootDir, "UnitTest1DataFile.csv");
licences = licenceChecker.CheckNoOfLicences(dataFile);
if (licences == 1)
{
    Console.WriteLine("Unit test 1 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 1 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 2." + Environment.NewLine);
dataFile = Path.Combine(newRootDir, "UnitTest2DataFile.csv");
licences = licenceChecker.CheckNoOfLicences(dataFile);
if (licences == 3)
{
    Console.WriteLine("Unit test 2 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 2 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 3." + Environment.NewLine);
dataFile = Path.Combine(newRootDir, "UnitTest3DataFile.csv");
licences = licenceChecker.CheckNoOfLicences(dataFile);
if (licences == 2)
{
    Console.WriteLine("Unit test 3 succeeded." + Environment.NewLine);
}
else
{
    throw new Exception("Unit test 3 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing testing sample-small.csv." + Environment.NewLine);
dataFile = Path.Combine(newRootDir, "sample-small.csv");
licences = licenceChecker.CheckNoOfLicences(dataFile);
Console.WriteLine("The number of licences required: " + licences.ToString() + Environment.NewLine);
#else
tryAgain:
Console.WriteLine("Please type the data file full path including name and extension, then press the Enter button twice." + Environment.NewLine);
dataFile = Console.ReadLine();
while (Console.ReadKey().Key != ConsoleKey.Escape) {
    //check if user supplied a valid data file path
    if (System.IO.File.Exists (dataFile))
    {
        licences = licenceChecker.CheckNoOfLicences(dataFile);
        Console.WriteLine("The number of licences required: " + licences.ToString() + Environment.NewLine);
        Console.WriteLine("To exit, please press the ESC button. " + Environment.NewLine);
    }
    else
    {
        Console.WriteLine("Invalid data file." + Environment.NewLine);
        goto tryAgain;
    }
}

Environment.Exit(0);
#endif


