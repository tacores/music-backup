using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    class DiContainer
    {
        private FileSystem fileSystem;
        private TextFileReadWriter textFile;
        private Setting setting;

        public DiContainer()
        {
            fileSystem = new FileSystemImpl();
            textFile = new TextFileReadWriterImpl();
            setting = new SettingXmlImpl(textFile);
        }

        public FileSystem getFileSystem()
        {
            return fileSystem;
        }

        public TextFileReadWriter getTextFileReadWriter()
        {
            return textFile;
        }

        public Setting getSetting()
        {
            return setting;
        }
    }
}
