using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraCodingTest
{
    public class Query: IQuery
    {
        private string? dataFile;
        private string? appID;

        public string DataFile
        {
            get { return dataFile; }
            set { dataFile = value; }
        }

        public string AppID
        {
            get { return appID; }
            set { appID = value; }
        }

    }
}
