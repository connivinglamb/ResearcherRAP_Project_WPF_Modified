using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ResearcherRAP_Project
{
    public static class XMLAdaptor
    {
        private static string filePath = "C:\\Users\\James\\source\\repos\\ResearcherRAP_Project_WPF_Modified\\WpfApp1\\Fundings_Rankings.xml"; //Please edit for your system
        public static int getFunding(int researcherID)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);

            int funding = 0;
            bool add;

            XmlNodeList projects = xml.SelectNodes("/Projects/Project");

            foreach (XmlNode project in projects)
            {
                add = false;
                XmlNodeList researchers = project.SelectNodes("Researchers/staff_id");
                foreach (XmlNode researcher in researchers)
                {
                    if (int.Parse(researcher.InnerText) == researcherID)
                    {
                        add = true;
                    }
                }
                if (add)
                {
                    funding += int.Parse(project["Funding"].InnerText);
                }
            }

            return funding;
        }
    }
}
