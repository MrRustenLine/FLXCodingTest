using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraCodingTest
{
    internal struct Computer
    {
        internal int ComputerID { get; set; }
        internal Computer(int computerID, int userID, int applicationID, string computerType )
        {
            ComputerID = computerID;
            UserID = userID;
            ApplicationID = applicationID;
            ComputerType = computerType.ToLower();

        }
        internal int UserID { get; set; }
        internal int ApplicationID { get; set; }

        internal string ComputerType { get; set; }

    }
}
