using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tests
{
    using NUnit.Framework;
    using mbackup;

    class SourceFolderTest
    {
        [Test]
        public void Constructor_Path()
        {
            SourceFolder sut = new SourceFolder("", @"C:\Music\Album");

            Assert.AreEqual(@"C:\Music\Album", sut.Path);
        }

        [Test]
        public void Constructor_Alias()
        {
            SourceFolder sut = new SourceFolder("Alias", "");

            Assert.AreEqual("Alias", sut.Alias);
        }
    }
}
