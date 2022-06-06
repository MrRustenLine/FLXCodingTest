using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraCodingTest
{
    public interface IQuery
    {
        public string DataFile {get; set; }

        public string AppID { get; set; }
    }
}
