﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraCodingTest
{
    public interface ILicenceChecker
    {
        public int CheckNoOfLicences(string dataFile, string appID);
    }
}
