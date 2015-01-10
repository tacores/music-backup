using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Linq;
using mbackup.Exceptions;

namespace mbackup
{
    public class SettingXmlImpl : Setting
    {
        private TextFileReadWriter fileReadWriter;
        private List<SourceFolder> srcFolders;
        private string dstFolder;
        private const string FileName = "mbackup.xml";

        public SettingXmlImpl(TextFileReadWriter fileReader)
        {
            this.fileReadWriter = fileReader;
            srcFolders = new List<SourceFolder>();
            dstFolder = "";

            try
            {
                loadXml();
            }
            catch (Exception)
            {
            }
        }

        private void loadXml()
        {
            string path = getXmlFilePath();
            string xml = getXmlString(path);
            parse(xml);
        }

        private string getXmlFilePath()
        {
            return FileName;
        }

        private string getXmlString(string filePath)
        {
            return fileReadWriter.read(filePath);
        }

        private void parse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            parseSrcPath(doc);
            parseDstPath(doc);
        }

        private void parseSrcPath(XDocument doc)
        {
            IEnumerable<XElement> folderDescendants =
                from el in doc.Descendants("SrcFolder")
                select el;
            foreach (XElement folderElement in folderDescendants)
            {
                XElement aliasElement = folderElement.Element("SrcAlias");
                XElement pathElement = folderElement.Element("SrcPath");

                string alias = aliasElement.Value;
                string path = pathElement.Value;

                SourceFolder folder = new SourceFolder(alias, path);
                srcFolders.Add(folder);
            }
        }

        private void parseDstPath(XDocument doc)
        {
            IEnumerable<XElement> de =
                from el in doc.Descendants("DstPath")
                select el;
            foreach (XElement el in de)
            {
                dstFolder = el.Value;
            }
        }

        public List<SourceFolder> getSrcFolders()
        {
            return srcFolders;
        }

        public void addSrcFolder(SourceFolder folder)
        {
            if (isPathContains(folder.Path))
            {
                throw new AlreadyExistException();
            }
            srcFolders.Add(folder);
            outputXmlFile();
        }

        private void outputXmlFile()
        {
            XDocument xdoc = createXmlDocument();
            fileReadWriter.write(FileName, xdoc.ToString());
        }

        private XDocument createXmlDocument()
        {
            XDocument xdoc = new XDocument(
                new XDeclaration(version: "1.0", encoding: "utf-8", standalone: null));
            XElement root = new XElement("mbackup");
            addSrcFolderElement(root);
            addDstFolderElement(root);
            xdoc.Add(root);
            return xdoc;
        }

        private void addSrcFolderElement(XElement root)
        {
            foreach (SourceFolder folder in srcFolders)
            {
                string path = folder.Path;
                string alias = folder.Alias;
                root.Add(
                    new XElement("SrcFolder",
                        new XElement("SrcAlias", new XText(alias)),
                        new XElement("SrcPath", new XText(path)))
                        );
            }
        }

        private void addDstFolderElement(XElement root)
        {
            if (dstFolder != "")
            {
                root.Add(
                    new XElement("DstFolder",
                        new XElement("DstPath", new XText(dstFolder)))
                        );
            }
        }

        public void removeSrcFolder(SourceFolder folder)
        {
            if (!isPathContains(folder.Path))
            {
                throw new InvalidOperationException();
            }
            srcFolders.Remove(folder);
            outputXmlFile();
        }

        public void changeSrcFolderAlias(SourceFolder folder)
        {
            outputXmlFile();
        }

        public void setDstFolder(string folderPath)
        {
            dstFolder = folderPath;
            outputXmlFile();
        }

        public string getDstFolder()
        {
            return dstFolder;
        }

        private bool isPathContains(string path)
        {
            foreach (SourceFolder folder in srcFolders)
            {
                if (folder.Path == path)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
