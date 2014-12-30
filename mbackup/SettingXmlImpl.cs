using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml.Linq;

namespace mbackup
{
    public class SettingXmlImpl : Setting
    {
        private TextFileReadWriter fileReadWriter;
        private List<string> srcFolders;

        public SettingXmlImpl(TextFileReadWriter fileReader)
        {
            this.fileReadWriter = fileReader;
            srcFolders = new List<string>();

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
            //string exePath = Assembly.GetEntryAssembly().Location;
            //return System.IO.Path.GetDirectoryName(exePath) + "\\mbackup.xml";
            return "mbackup.xml";
        }

        private string getXmlString(string filePath)
        {
            return fileReadWriter.read(filePath);
        }

        private void parse(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<XElement> de =
                from el in doc.Descendants("SrcPath")
                select el;
            foreach (XElement el in de)
            {
                srcFolders.Add(el.Value);
            }
        }

        public List<string> getSrcFolders()
        {
            return srcFolders;
        }

        public void addSrcFolder(string folder)
        {
        }
    }
}
