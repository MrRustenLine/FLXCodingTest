using FlexeraCodingTest;

int licences = 0;
string dataFile = "";

#if DEBUG
//Conduct unit tests below.
string rootDir = System.IO.Directory.GetCurrentDirectory();
string newDir = Path.GetFullPath(Path.Combine(rootDir, @"..\..\..\"));
Console.WriteLine("Commencing unit test 1." + Environment.NewLine);
dataFile = Path.Combine(newDir, "UnitTest1DataFile.csv");
licences = LicenceChecker.CheckNoOfLicences(dataFile);
if (licences == 1)
{
    Console.WriteLine("Unit test 1 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 1 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 2." + Environment.NewLine);
dataFile = Path.Combine(newDir, "UnitTest2DataFile.csv");
licences = LicenceChecker.CheckNoOfLicences(dataFile);
if (licences == 3)
{
    Console.WriteLine("Unit test 2 succeeded." + Environment.NewLine);
}
else 
{
    throw new Exception("Unit test 2 failed!" + Environment.NewLine);
}
Console.WriteLine("Commencing unit test 3." + Environment.NewLine);
dataFile = Path.Combine(newDir, "UnitTest3DataFile.csv");
licences = LicenceChecker.CheckNoOfLicences(dataFile);
if (licences == 2)
{
    Console.WriteLine("Unit test 3 succeeded." + Environment.NewLine);
}
else
{
    throw new Exception("Unit test 3 failed!" + Environment.NewLine);
}
dataFile = Path.Combine(newDir, "sample-small.csv");
licences = LicenceChecker.CheckNoOfLicences(dataFile);
Console.WriteLine("Licenses No in " + dataFile + "" + licences.ToString() + Environment.NewLine);
Console.WriteLine("The number of licences required: " + licences.ToString() + Environment.NewLine);
#else
Console.WriteLine("Please enter the full path of the data file including the file itself, then hit Enter" + Environment.NewLine);
dataFile = Console.ReadLine();
//check if user supplied full data file path
if (dataFile == "") {
    Console.WriteLine("Please restart a program, and next time supply the valid full path of the data file including data file name.");
}
else
{
    licences = LicenceChecker.CheckNoOfLicences(dataFile);
    Console.WriteLine("The number of licences required: " + licences.ToString() + Environment.NewLine);
}
Console.WriteLine("Press ESC to exit the program" + Environment.NewLine);
while (Console.ReadKey().Key != ConsoleKey.Escape) {}
Environment.Exit(0);
#endif


