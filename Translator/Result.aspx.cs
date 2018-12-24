using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Translator
{
    public partial class Result : System.Web.UI.Page
    {
        private static int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = Session["TranslationResult"].ToString();
            string from = Session["TranslationInput"].ToString();
            GenerateIdForXmlFile();
            CreateXmlFile(lblResult.Text, from, id);
        }

        public void CreateXmlFile(string text, string from, int id)
        {

            var assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryPath = Path.GetDirectoryName(assemblyPath);
            var filePath = Path.Combine(directoryPath, "Log.xml");

            using (XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("translations");

                writer.WriteStartElement("translation");

                writer.WriteAttributeString("timestamp", DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));
                writer.WriteAttributeString("id", id.ToString());
                writer.WriteElementString("from", from);
                writer.WriteElementString("to", lblResult.Text);

                writer.WriteEndElement();


                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void GenerateIdForXmlFile()
        {
            id += 1;
        }
    }
}