using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    public interface TextFileReadWriter
    {
        string read(string fileName);

        void write(string fileName, string content);
    }
}
