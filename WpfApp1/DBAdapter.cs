using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ResearcherRAP_Project
{
    class DBAdapter
    {
        private static MySqlConnection conn;
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = ("Database=kit206;Data Source=alacritas.cis.utas.edu.au;User ID=kit206;Password=kit206");

                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<ResearcherBrief> researcherBriefQuery()
        {
            List<ResearcherBrief> newResearcherBriefArray = new List<ResearcherBrief>();
            MySqlDataReader dbReader = null;
            try
            {
                GetConnection();
                conn.Open();
                Debug.WriteLine(conn);
                MySqlCommand getResearcherBrief = new MySqlCommand("SELECT id, type, given_name, family_name,title,level FROM researcher", conn);
                dbReader = getResearcherBrief.ExecuteReader();

                while (dbReader.Read())
                {
                    ResearcherType researcherType = (ResearcherType)dbReader[1];
                    ResearcherLevel researcherLevel = (ResearcherLevel)dbReader[5];
                    string researcherNameFirst = (string)dbReader[2];
                    string researcherNameLast = (string)dbReader[3];
                    string researcherTitle = (string)dbReader[4];
                    int researcherID = (int)dbReader[0];

                    newResearcherBriefArray.Add(new ResearcherBrief(researcherType, researcherLevel, researcherNameFirst, researcherNameLast, researcherTitle, researcherID));
                }
            }

            catch
            {
                Debug.WriteLine("Exception Thrown!");
            }

            finally
            {
                if (dbReader != null)
                { dbReader.Close(); }
                if (conn != null)
                { conn.Close(); }
            }
            return newResearcherBriefArray;
        }

        public static List<ResearcherDetailed> researcherDetailedQuery(int researcherID) 
        {
            List<ResearcherDetailed> newResearcherDetailedArray = new List<ResearcherDetailed>();
            return newResearcherDetailedArray;
        }

        public static List<PublicationBrief> publicationBriefQuery()
        {
            List<PublicationBrief> newPublicationBriefArray = new List<PublicationBrief>(); //establishes publication array instantiation in memory
            newPublicationBriefArray.Add(new PublicationBrief("computationally expensive", "1995")); // pretend if this is a SELECT * FROM Retrieval query and iteration from a FOR loop
            newPublicationBriefArray.Add(new PublicationBrief("research1", "1993"));
            return newPublicationBriefArray;
        }

        public static List<PublicationDetailed> publicationDetailedQuery(int researcherID) 
        { // modify int values to date objects later

            List<PublicationDetailed> newPublicationArray = new List<PublicationDetailed>();
            return newPublicationArray;
        }

        public static List<PublicationBrief> publicationBriefQeuery(int researcherID)
        {
            List<PublicationBrief> newPublicationBriefArray = new List<PublicationBrief>();

            return newPublicationBriefArray;
        }

        public static List<ResearcherSupervision> supervisionsQuery(int researcherID)
        {
            List<ResearcherSupervision> newSupervisionsArray = new List<ResearcherSupervision>();

            return newSupervisionsArray;
        }
        
    }
}
