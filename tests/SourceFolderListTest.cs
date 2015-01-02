using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tests
{
    using NUnit.Framework;
    using mbackup;

    class SourceFolderListTest
    {
        private SourceFolderList sut;

        [SetUp]
        public void Init()
        {
            sut = new SourceFolderList();
        }

        [Test]
        public void GetList_Initial_ReturnsEmptyList()
        {
            Assert.AreEqual(0, sut.getList().Count);
        }

        [Test]
        public void Add_One_Count()
        {
            sut.add(@"C:\Music\Album");

            Assert.AreEqual(1, sut.getList().Count);
        }

        [Test]
        public void Add_One_Path()
        {
            sut.add(@"C:\Music\Album");

            Assert.AreEqual(@"C:\Music\Album", sut.getList().ElementAt(0).Path);
        }

        [Test]
        public void Add_One_Alias()
        {
            sut.add(@"C:\Music\Album");

            Assert.AreEqual("Album", sut.getList().ElementAt(0).Alias);
        }

        [Test]
        public void Add_One_ReturnsSourceFolder()
        {
            SourceFolder ret = sut.add(@"C:\Music\Album");

            Assert.AreEqual(@"C:\Music\Album", ret.Path);
            Assert.AreEqual("Album", ret.Alias);
        }

        [Test]
        public void Add_Two_DifferentName_Path()
        {
            sut.add(@"C:\Music\Album");
            sut.add(@"D:\Music\itunes");

            Assert.AreEqual(@"C:\Music\Album", sut.getList().ElementAt(0).Path);
            Assert.AreEqual(@"D:\Music\itunes", sut.getList().ElementAt(1).Path);
        }

        [Test]
        public void Add_Two_DifferentName_Alias()
        {
            sut.add(@"C:\Music\Album");
            sut.add(@"D:\Music\itunes");

            Assert.AreEqual("Album", sut.getList().ElementAt(0).Alias);
            Assert.AreEqual("itunes", sut.getList().ElementAt(1).Alias);
        }

        [Test]
        public void Add_Two_SameName_Path()
        {
            sut.add(@"C:\Music");
            sut.add(@"D:\Music");

            Assert.AreEqual(@"C:\Music", sut.getList().ElementAt(0).Path);
            Assert.AreEqual(@"D:\Music", sut.getList().ElementAt(1).Path);
        }

        [Test]
        public void Add_Two_SameName_Alias()
        {
            sut.add(@"C:\Music");
            sut.add(@"D:\Music");

            Assert.AreEqual("Music", sut.getList().ElementAt(0).Alias);
            Assert.AreEqual("Music(2)", sut.getList().ElementAt(1).Alias);
        }

        [Test]
        public void Add_ReplaceAlias_Max()
        {
            sut.add(@"C:\Music");
            sut.add(@"D:\Music");
            sut.add(@"E:\Music");
            sut.add(@"F:\Music");
            sut.add(@"G:\Music");
            sut.add(@"H:\Music");
            sut.add(@"I:\Music");
            sut.add(@"J:\Music");
            sut.add(@"K:\Music");

            Assert.AreEqual("Music(9)", sut.getList().ElementAt(8).Alias);
        }

        [Test]
        public void Add_TooManySameFolderName_ThrowInvalidOperation()
        {
            sut.add(@"C:\Music");
            sut.add(@"D:\Music");
            sut.add(@"E:\Music");
            sut.add(@"F:\Music");
            sut.add(@"G:\Music");
            sut.add(@"H:\Music");
            sut.add(@"I:\Music");
            sut.add(@"J:\Music");
            sut.add(@"K:\Music");

            try
            {
                sut.add(@"L:\Music");
            }
            catch(InvalidOperationException)
            {
                return;
            }
            Assert.Fail("InvalidOperationException was not thrown.");
        }

        [Test]
        public void Remove_Count()
        {
            SourceFolder ret = sut.add(@"C:\Music\Album");
            sut.remove(ret);

            Assert.AreEqual(0, sut.getList().Count);
        }

        [Test]
        public void Remove_Clear_AliasSetToo()
        {
            SourceFolder ret = sut.add(@"C:\Music\Album");
            sut.remove(ret);
            sut.add(@"C:\Music\Album");

            Assert.AreEqual("Album", sut.getList().ElementAt(0).Alias);
        }

        [Test]
        public void AddSrcFolder_One_Count()
        {
            SourceFolder src = new SourceFolder("alias1", @"C:\Music");
            sut.add(src);

            Assert.AreEqual(1, sut.getList().Count);
        }

        [Test]
        public void AddSrcFolder_One_Path()
        {
            SourceFolder src = new SourceFolder("alias1", @"C:\Music");
            sut.add(src);

            Assert.AreEqual(@"C:\Music", sut.getList().ElementAt(0).Path);
        }
 
        [Test]
        public void AddSrcFolder_One_Alias()
        {
            SourceFolder src = new SourceFolder("alias1", @"C:\Music");
            sut.add(src);

            Assert.AreEqual("alias1", sut.getList().ElementAt(0).Alias);
        }

        [Test]
        public void AddSrcFolder_AliasListIsAddedToo()
        {
            SourceFolder src = new SourceFolder("Alias", @"C:\Music");
            sut.add(src);
            sut.add(@"C:\Music\Alias");

            Assert.AreEqual("Alias(2)", sut.getList().ElementAt(1).Alias);
        }

    }
}
