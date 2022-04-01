using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

/* Author: Rusten Line
 * Date: 27.3.22
 * Desc: The licence checker class is tasked with evaluating the number of lincences.
 * It is based on Singleton design pattern.
 */
namespace FlexeraCodingTest
{
    
     public static class LicenceChecker
    {
        private static List<Computer> GetComputers(string dataFile)
        {
            List<Computer> computers = new List<Computer>();
            using (StreamReader sr = new StreamReader(dataFile))
            {
                try
                {
                    string ds = sr.ReadToEnd();
                    string[] table = ds.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    for (int rowCount = 1; rowCount < table.Length; rowCount++)
                    {
                        string[] row = SmartSplit(table[rowCount]);
                        int appID = int.Parse(row[2]);
                        if (appID == 374)
                        {
                            Computer computer = new Computer(int.Parse(row[0]), int.Parse(row[1]), int.Parse(row[2]), row[3].ToLower());
                            computers.Add(computer);
                        }
                    }
                }
                catch (IndexOutOfRangeException iorEx)
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to process the data file in GetComputers() " + Environment.NewLine + ex.Message);
                    throw;
                }
                return computers;
            }
        }
        public static int CheckNoOfLicences(string dataFile)
        {
            Console.WriteLine("Commencing to check licences. Please wait..." + Environment.NewLine);
            try
            {        
                List<Computer> pCs = GetComputers(dataFile);             
                List<Computer> checkedPCs = new List<Computer>();
                List<Computer> licensedPCs = new List<Computer>();
                List<Computer> licensedPCsBelongingToUser = new List<Computer>();
                int licences = 0;
                int noOfLicensedPCsBelongingToUser =0;
                foreach (Computer pC in pCs)
                {
                    licences++;
                    if (checkedPCs.Contains(pC))
                    {
                        // We checked this computer before.
                        licences--;
                        continue;
                    }
                    else
                    {
                        checkedPCs.Add(pC);
                        licensedPCsBelongingToUser = licensedPCs.Where(licensedPC => licensedPC.UserID == pC.UserID).ToList();
                        noOfLicensedPCsBelongingToUser = licensedPCsBelongingToUser.Count;
                        switch (noOfLicensedPCsBelongingToUser)
                        {
                            case 0:
                                licensedPCs.Add(pC);
                                continue;
                            case 1:
                                if ((pC.ComputerType == "desktop") & (licensedPCsBelongingToUser[0].ComputerType == "desktop"))
                                {
                                    licensedPCs.Add(pC);
                                    continue;
                                }
                                else
                                {
                                    licences--;
                                    continue;
                                }
                            case 2:
                                // UserUD reached the maximum number of licences
                                licences--;
                                continue;
                        }
                    }
                }
                    
                Console.WriteLine("Finished checking licences successfully. " + Environment.NewLine);
                return licences;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Finished checking licences failed. " + Environment.NewLine);
                throw;
            }
        }

        private static string[] SmartSplit(string line, char separator = ',')
        {
            var inQuotes = false;
            var token = "";
            var lines = new List<string>();
            for (var i = 0; i < line.Length; i++)
            {
                var ch = line[i];
                if (inQuotes) // process string in quotes, 
                {
                    if (ch == '"')
                    {
                        if (i < line.Length - 1 && line[i + 1] == '"')
                        {
                            i++;
                            token += '"';
                        }
                        else inQuotes = false;
                    }
                    else token += ch;
                }
                else
                {
                    if (ch == '"') inQuotes = true;
                    else if (ch == separator)
                    {
                        lines.Add(token);
                        token = "";
                    }
                    else token += ch;
                }
            }
            lines.Add(token);
            return lines.ToArray();
        }

    }

    
}
