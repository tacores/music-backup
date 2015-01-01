using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mbackup
{
    class TextFileReadWriterImpl : TextFileReadWriter
    {
        public string read(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        public void write(string filePath, string content)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(content);
            }
        }
    }
}
