using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tests
{
    using NUnit.Framework;
    using mbackup;
    using stub;

    public class SettingXmlTest
    {
        private SettingXmlImpl sut;
        private TextFileReadWriterStub textFile;

        [SetUp]
        public void Init()
        {
            textFile = new TextFileReadWriterStub();
            sut = new SettingXmlImpl(textFile);
        }

        private SettingXmlImpl createSut()
        {
            sut = new SettingXmlImpl(textFile);
            return sut;
        }

        [Test]
        public void GetSrcFolderReturnsEmptyArray_WhenFileDoseNotExist()
        {
            textFile.setRead("");

            List<string> result = sut.getSrcFolders();

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void GetSrcFolder_One_Count()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            List<string> result = sut.getSrcFolders();

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetSrcFolder_One_Path()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            List<string> result = sut.getSrcFolders();

            Assert.AreEqual(@"C:\Music", result.ElementAt(0));
        }

        [Test]
        public void GetSrcFolder_Two_Count()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
<SrcFolder><SrcPath>D:\Music2</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            List<string> result = sut.getSrcFolders();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetSrcFolder_Two_Path()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
<SrcFolder><SrcPath>D:\Music2</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            List<string> result = sut.getSrcFolders();

            Assert.AreEqual(@"C:\Music", result.ElementAt(0));
            Assert.AreEqual(@"D:\Music2", result.ElementAt(1));
        }
    }
}
