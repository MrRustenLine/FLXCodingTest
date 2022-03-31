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
            using (StreamReader sr = new StreamReader(dataFile))
            {
                try
                {
                    string ds = sr.ReadToEnd();
                    string[] table = ds.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    List<Computer> computers = new List<Computer>();
                    for (int rowCount = 0; rowCount < table.Length; rowCount++)
                    {
                        string[] row = SmartSplit(table[rowCount]);
                        Computer computer = new Computer(int.Parse(row[0]), int.Parse(row[1]), int.Parse(row[2]), row[3].ToLower(), row[4].ToLower());
                        computers.Add(computer);
                    }
                    return computers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to process the data file in GetComputers(). " + Environment.NewLine);
                    throw;
                }
            }
        }
        public static int CheckNoOfLicences(string dataFile)
        {
            Console.WriteLine("Commencing to check licences. Please wait..." + Environment.NewLine);
            try
            {        
                int licenceNo = 0;
                List<Computer> computers = GetComputers(dataFile);
                List<Computer> checkedComputers = new List<Computer>();
                foreach(Computer computer in computers)
                {
                    if (computer.ApplicationID == 374)
                    {
                        // We checked this computer before.
                        if (checkedComputers.Contains(computer))
                        {
                            continue;
                        }
                        else
                        {
                            //Did this userID install it on 2 machines already?
                            if (checkedComputers.Where(checkedComputer => checkedComputer.UserID == computer.UserID).Any())
                            {
                                continue;
                            }
                            else
                            {
                                checkedComputers.Add(computer);
                                //Is one of the machines in the checkedComputers a laptop?
                                // continue
                                // else
                                // 
                                //licenceNo++;
                            }

                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                    
                Console.WriteLine("Finished checking licences successfully. " + Environment.NewLine);
                return licenceNo;
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
