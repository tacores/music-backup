using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tests.stub
{
    using mbackup;

    public class TextFileReadWriterStub : TextFileReadWriter
    {
        private string str;
        private string writeContent;
        public TextFileReadWriterStub()
        {
            str = "";
            writeContent = "";
        }

        public string read(string fileName)
        {
            return str;
        }
        public void setRead(string str)
        {
            this.str = str;
        }

        public void write(string fileName, string content)
        {
            writeContent = content;
        }
        public string getWriteContent()
        {
            return writeContent;
        }
    }
}
