using FlexeraCodingTest;

int noOfLicences = 0;
string dataFile = "";

#if DEBUG
//Conduct unit tests below.
string rootDir = System.IO.Directory.GetCurrentDirectory();
Console.WriteLine("Commencing unit test 1." + Environment.NewLine);
dataFile = Path.Combine(rootDir, "UnitTest1DataFile.csv");
noOfLicences = LicenceChecker.CheckNoOfLicences(dataFile);
if (noOfLicences == 1)
{
    Console.WriteLine("Unit test 1 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 1 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 2." + Environment.NewLine);
dataFile = Path.Combine(rootDir, "UnitTest2DataFile.csv");
noOfLicences = LicenceChecker.CheckNoOfLicences(dataFile);
if (noOfLicences == 3)
{
    Console.WriteLine("Unit test 2 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 2 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 3." + Environment.NewLine);
dataFile = Path.Combine(rootDir, "UnitTest3DataFile.csv");
noOfLicences = LicenceChecker.CheckNoOfLicences(dataFile);
if (noOfLicences == 2)
{
    Console.WriteLine("Unit test 3 succeeded." + Environment.NewLine);
}
else
{
    throw new Exception("Unit test 3 failed!" + Environment.NewLine);
}
Console.WriteLine("The number of licences required: " + noOfLicences.ToString() + Environment.NewLine);
#else
Console.WriteLine("Please enter the full path of the data file including the file itself, then hit Enter" + Environment.NewLine);
dataFilePath = Console.ReadLine();
//check if user supplied full data file path
if (dataFilePath == "") {
    Console.WriteLine("Please restart a program, and next time supply the valid full path of the data file including data file name.");
}
else
{
    licenceNo = LicenceChecker.CheckLicenceNo(dataFilePath);
    Console.WriteLine("The number of licences required: " + licenceNo.ToString() + Environment.NewLine);
}
Console.WriteLine("Press ESC to exit the program" + Environment.NewLine);
while (Console.ReadKey().Key != ConsoleKey.Escape) {}
Environment.Exit(0);
#endif


