/* Author: Rusten Line
 * Date: 27.3.22
 * Desc: The app is written as a sysadmin console app.
 */

using FLXCodingTest;

tryAgain:
int licences = 0;
string dataFile = "";
string appID = "";

Console.WriteLine("Please supply the full path of a data file including its name and extension, then press Enter." + Environment.NewLine);
dataFile = Console.ReadLine();

while (Console.ReadKey().Key != ConsoleKey.Escape) {
    //check if user supplied a valid data file 
    if (System.IO.File.Exists (dataFile))
    {
        enterValidAppID:
        Console.WriteLine("Please enter a valid appID, then press Enter. " + Environment.NewLine);
        appID = Console.ReadLine();

        if (appID != "")
        {
            // Dependency injection using constructor
            LicenceChecker licenceChecker = new LicenceChecker(new SearchParameters(dataFile, appID));
            licences = licenceChecker.CheckLicences();
        }
        else
        {
            goto enterValidAppID;
        }

        Console.WriteLine("The number of licences required: " + licences.ToString() + Environment.NewLine);
        Console.WriteLine("To exit, please press the ESC button." + Environment.NewLine);
    }
    else
    {
        Console.WriteLine("Invalid data file." + Environment.NewLine);
        goto tryAgain;
    }
}

Environment.Exit(0);


