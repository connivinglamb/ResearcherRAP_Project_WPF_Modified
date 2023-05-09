using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = ("Database=kit206;Data Source=alacritas.cis.utas.edu.au;User ID=kit206;Password=kit206");

                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<ResearcherBrief> ResearcherBriefQuery()
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
                    ResearcherType researcherType = ParseEnum<ResearcherType>(dbReader.GetString(1));
                    ResearcherLevel? researcherLevel;
                    if (dbReader.IsDBNull(5))
                    {
                        researcherLevel = null;
                    }
                    else
                    {
                        researcherLevel = (ResearcherLevel?)ParseEnum<ResearcherLevel>(dbReader.GetString(5));
                    }
                    
                    string researcherNameFirst = dbReader.GetString(2);
                    string researcherNameLast = dbReader.GetString(3);
                    string researcherTitle = dbReader.GetString(4);
                    int researcherID = dbReader.GetInt32(0);

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

        public static ObservableCollection<ResearcherDetailed> researcherDetailedQuery(int researcherID) 
        {
            ObservableCollection<ResearcherDetailed> newResearcherDetailedArray = new ObservableCollection<ResearcherDetailed>();
            MySqlDataReader dbReader = null;

            try
            {
                GetConnection();
                conn.Open();
                Debug.WriteLine(conn);

                MySqlCommand getResearcherBrief = new MySqlCommand("SELECT * FROM researcher WHERE id = @newID", conn);
                getResearcherBrief.Parameters.Add("@newID", MySqlDbType.Int64);
                getResearcherBrief.Parameters["@newID"].Value = researcherID;
                dbReader = getResearcherBrief.ExecuteReader();
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
            return newResearcherDetailedArray;
        }

        public static ObservableCollection<PublicationBrief> publicationBriefQuery()
        {
            ObservableCollection<PublicationBrief> newPublicationBriefArray = new ObservableCollection<PublicationBrief>(); //establishes publication array instantiation in memory
            newPublicationBriefArray.Add(new PublicationBrief("computationally expensive", "1995")); // pretend if this is a SELECT * FROM Retrieval query and iteration from a FOR loop
            newPublicationBriefArray.Add(new PublicationBrief("research1", "1993"));
            return newPublicationBriefArray;
        }

        public static ObservableCollection<PublicationDetailed> publicationDetailedQuery(int researcherID) 
        { // modify int values to date objects later

            ObservableCollection<PublicationDetailed> newPublicationArray = new ObservableCollection<PublicationDetailed>();
            return newPublicationArray;
        }

        public static ObservableCollection<PublicationBrief> publicationBriefQeuery(int researcherID)
        {
            ObservableCollection<PublicationBrief> newPublicationBriefArray = new ObservableCollection<PublicationBrief>();

            return newPublicationBriefArray;
        }

        public static ObservableCollection<ResearcherSupervision> supervisionsQuery(int researcherID)
        {
            ObservableCollection<ResearcherSupervision> newSupervisionsArray = new ObservableCollection<ResearcherSupervision>();

            return newSupervisionsArray;
        }
        
    }
}
