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
        private List<string> srcFolders;
        private string dstFolder;
        private const string FileName = "mbackup.xml";

        public SettingXmlImpl(TextFileReadWriter fileReader)
        {
            this.fileReadWriter = fileReader;
            srcFolders = new List<string>();
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
            IEnumerable<XElement> de =
                from el in doc.Descendants("SrcPath")
                select el;
            foreach (XElement el in de)
            {
                srcFolders.Add(el.Value);
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

        public List<string> getSrcFolders()
        {
            return srcFolders;
        }

        public void addSrcFolder(string folder)
        {
            if (srcFolders.Contains(folder))
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
            foreach (string path in srcFolders)
            {
                root.Add(
                    new XElement("SrcFolder",
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

        public void removeSrcFolder(string folderPath)
        {
            if (!srcFolders.Contains(folderPath))
            {
                throw new InvalidOperationException();
            }
            srcFolders.Remove(folderPath);
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
    }
}
