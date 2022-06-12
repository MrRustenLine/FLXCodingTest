global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Configuration;

/* Author: Rusten Line
 * Date: 27.3.22
 * Desc: The licence checker class is tasked with evaluating the required number of per device licences.
 */
namespace FLXCodingTest
{

    public class LicenceChecker: ILicenceChecker
    {
        #region "Public"

        public LicenceChecker(ISearchParameters searchParameters) => _searchParameters = searchParameters;

        public int CheckLicences ()
        {
            Console.WriteLine("Commencing to check licences. Please wait..." + Environment.NewLine);
            try
            {
                List<Computer>? pCs = GetComputers();
                List<Computer> checkedPCs = new List<Computer>();
                List<Computer> licensedPCs = new List<Computer>();
                List<Computer> licensedPCsBelongingToUser = new List<Computer>();
                int licences = 0;
                int noOfLicensedPCsBelongingToUser = 0;
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
                                {   // one of the PCs is a laptop
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

        #endregion

        #region "Private"

        ISearchParameters _searchParameters;
        private List<Computer>? GetComputers()
        {
            List<Computer> computers = new List<Computer>();
            try
            {
                using (StreamReader reader = new StreamReader(_searchParameters.DataFile))
                {
                    // split line by line otherwise it could be too memory intensive.
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (values[2] == _searchParameters.AppID)
                        {
                            // We are not interested in Comment field.
                            Computer computer = new Computer(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), values[3].ToLower());
                            computers.Add(computer);
                        }
                    }
                    return computers;
                }
            }
            //If data files contain some unexpected formating.
            catch (IndexOutOfRangeException iorEx)
            {

                Console.WriteLine("IndexOutOfRangeException - Check characters at the end of the file! " + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to process the data file in GetComputers(). " + Environment.NewLine + ex.Message);
                throw;
            }
            return null;
        }
        #endregion

    }
    
}
