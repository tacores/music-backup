using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace tests
{
    using NUnit.Framework;
    using mbackup;
    using stub;
    using mbackup.Exceptions;

    public class SettingXmlTest
    {
        private SettingXmlImpl sut;
        private TextFileReadWriterStub textFile;
        private List<string> srcFoldersList;
        private string dstFolder;

        [SetUp]
        public void Init()
        {
            textFile = new TextFileReadWriterStub();
            sut = new SettingXmlImpl(textFile);
            srcFoldersList = new List<string>();
        }

        private SettingXmlImpl createSut()
        {
            sut = new SettingXmlImpl(textFile);
            return sut;
        }

        private void parseXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                {
                    IEnumerable<XElement> de =
                        from el in doc.Descendants("SrcPath")
                        select el;
                    foreach (XElement el in de)
                    {
                        srcFoldersList.Add(el.Value);
                    }
                }
                {
                    IEnumerable<XElement> de =
                        from el in doc.Descendants("DstPath")
                        select el;
                    foreach (XElement el in de)
                    {
                        dstFolder = el.Value;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        [Test]
        public void GetSrcFolderReturnsEmptyArray_WhenFileDoseNotExist()
        {
            textFile.setRead("");

            List<SourceFolder> result = sut.getSrcFolders();

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

            List<SourceFolder> result = sut.getSrcFolders();

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

            List<SourceFolder> result = sut.getSrcFolders();

            Assert.AreEqual(@"C:\Music", result.ElementAt(0).Path);
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

            List<SourceFolder> result = sut.getSrcFolders();

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

            List<SourceFolder> result = sut.getSrcFolders();

            Assert.AreEqual(@"C:\Music", result.ElementAt(0).Path);
            Assert.AreEqual(@"D:\Music2", result.ElementAt(1).Path);
        }

        [Test]
        public void AddSrcFolder_One_Count()
        {
            sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(1, srcFoldersList.Count);
        }

        [Test]
        public void AddSrcFolder_One_Path()
        {
            sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(@"C:\Music", srcFoldersList.ElementAt(0));
        }

        [Test]
        public void AddSrcFolder_Two_Count()
        {
            sut.addSrcFolder(new SourceFolder("Music1", @"C:\Music1"));
            sut.addSrcFolder(new SourceFolder("Music2", @"C:\Music2"));

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(2, srcFoldersList.Count);
        }

        [Test]
        public void AddSrcFolder_Two_Path()
        {
            sut.addSrcFolder(new SourceFolder("Music1", @"C:\Music1"));
            sut.addSrcFolder(new SourceFolder("Music2", @"C:\Music2"));

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(@"C:\Music1", srcFoldersList.ElementAt(0));
            Assert.AreEqual(@"C:\Music2", srcFoldersList.ElementAt(1));
        }

        [Test]
        public void AddSrcFolder_SamePath_ThrowAlreadyExist()
        {
            sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));
            try
            {
                sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));
            }
            catch (AlreadyExistException)
            {
                return;
            }
            Assert.Fail("AlreadyExistException was not thrown.");
        }

        [Test]
        public void AddSrcFolder_SamePath_CountIsNotIncremented()
        {
            sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));
            try
            {
                sut.addSrcFolder(new SourceFolder("Music", @"C:\Music"));
            }
            catch (AlreadyExistException)
            {
                string xml = textFile.getWriteContent();
                parseXml(xml);
                Assert.AreEqual(1, srcFoldersList.Count);
                return;
            }
            Assert.Fail("AlreadyExistException was not thrown.");
        }

        [Test]
        public void RemoveSrcFolder_NoExist_ThrowInvalidOperation()
        {
            try
            {
                sut.removeSrcFolder(new SourceFolder("Music", @"C:\Music"));
            }
            catch (InvalidOperationException)
            {
                return;
            }
            Assert.Fail("InvalidOperationException was not thrown.");
        }

        [Test]
        public void RemoveSrcFolder_CountBecomesOne()
        {
            //setup
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            //exercise
            SourceFolder folder = sut.getSrcFolders().ElementAt(0);
            sut.removeSrcFolder(folder);

            //verify
            string xml = textFile.getWriteContent();
            parseXml(xml);
            Assert.AreEqual(0, srcFoldersList.Count);
        }

        [Test]
        public void RemoveSrcFolder_CountBecomesTwo()
        {
            //setup
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
<SrcFolder><SrcPath>C:\Music2</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            //exercise
            SourceFolder folder = sut.getSrcFolders().ElementAt(0);
            sut.removeSrcFolder(folder);

            //verify
            string xml = textFile.getWriteContent();
            parseXml(xml);
            Assert.AreEqual(1, srcFoldersList.Count);
        }

        [Test]
        public void RemoveSrcFolder_Path()
        {
            //setup
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<SrcFolder><SrcPath>C:\Music</SrcPath></SrcFolder>
<SrcFolder><SrcPath>C:\Music2</SrcPath></SrcFolder>
</mbackup>");
            sut = createSut();

            //exercise
            SourceFolder folder = sut.getSrcFolders().ElementAt(0);
            sut.removeSrcFolder(folder);

            //verify
            string xml = textFile.getWriteContent();
            parseXml(xml);
            Assert.AreEqual(@"C:\Music2", srcFoldersList.ElementAt(0));
        }

        [Test]
        public void GetDstFolder_FromFile()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<DstFolder><DstPath>F:\backup</DstPath></DstFolder>
</mbackup>");
            sut = createSut();

            Assert.AreEqual(@"F:\backup", sut.getDstFolder());
        }

        [Test]
        public void SetDstFolder_Once()
        {
            sut.setDstFolder(@"F:\backup");

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(@"F:\backup", dstFolder);
        }

        [Test]
        public void SetDstFolder_Overwrite()
        {
            textFile.setRead(@"<?xml version=""1.0"" encoding=""utf-8""?>
<mbackup>
<DstFolder><DstPath>F:\backup</DstPath></DstFolder>
</mbackup>");
            sut = createSut();
            sut.setDstFolder(@"F:\backup2");

            string xml = textFile.getWriteContent();
            parseXml(xml);

            Assert.AreEqual(@"F:\backup2", dstFolder);
        }
    }
}
