/* Author: Rusten Line
 * Date: 27.3.22
 * Desc: The app is written as a sysadmin console app.
 */

using FlexeraCodingTest;

tryAgain:
int licences = 0;
IQuery query = null;
string dataFile = "";
string appID = "";

Console.WriteLine("Please type the full path of a data file including its name and extension, then press the Enter button." + Environment.NewLine);
dataFile = Console.ReadLine();
while (Console.ReadKey().Key != ConsoleKey.Escape) {
    //check if user supplied a valid data file path
    if (System.IO.File.Exists (dataFile))
    {
        Console.WriteLine(Environment.NewLine + "Please enter appID.");
        appID = Console.ReadLine();
        if (appID != "")
        {
            if (query == null)
            {
                query = new Query();
                query.AppID = appID;
                query.DataFile=dataFile;
            }
            LicenceChecker licenceChecker = new LicenceChecker();
            licences = licenceChecker.CheckNoOfLicences(query);
        }
        else
        {
            Console.WriteLine("Please enter a valid appID, then press the Enter button. " + Environment.NewLine);
            goto tryAgain;
        }
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


