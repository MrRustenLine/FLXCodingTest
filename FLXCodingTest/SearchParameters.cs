using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLXCodingTest
{
    public class SearchParameters: ISearchParameters
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

        public SearchParameters(string? dataFile, string? appID)
        {
            DataFile = dataFile;
            AppID = appID;
        }
    }
}
