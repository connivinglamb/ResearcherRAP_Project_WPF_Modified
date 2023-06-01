using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;
using Org.BouncyCastle.Asn1.Crmf;

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
                if (dbReader != null) { dbReader.Close(); }
                if (conn != null) { conn.Close(); }
            }
            return newResearcherBriefArray;
        }

        public static ResearcherDetailed researcherDetailedQuery(int researcherID) 
        {
            MySqlDataReader dbReader = null;
            ResearcherDetailed newResearcherDetailed = null;

            try
            {
                GetConnection();
                conn.Open();
                Debug.WriteLine(conn);

                MySqlCommand getResearcherDetails = new MySqlCommand("SELECT * FROM researcher WHERE id = @newID", conn);
                getResearcherDetails.Parameters.Add("@newID", MySqlDbType.Int64);
                getResearcherDetails.Parameters["@newID"].Value = researcherID;
                dbReader = getResearcherDetails.ExecuteReader();

                dbReader.Read();

                string nameGiven = dbReader.GetString(2);
                string nameFamily = dbReader.GetString(3);
                string title = dbReader.GetString(4);
                string schoolOrUnit = dbReader.GetString(5);
                string email = dbReader.GetString(7);
                string photo = dbReader.GetString(8);
                string currentJobTitle = "Student";
                if (!dbReader.IsDBNull(11))
                {
                    switch (dbReader.GetString(11))
                    {
                        case "A":
                            currentJobTitle = "Research Associate";
                            break;
                        case "B":
                            currentJobTitle = "Lecturer";
                            break;
                        case "C":
                            currentJobTitle = "Assistant Professor";
                            break;
                        case "D":
                            currentJobTitle = "Associate Professor";
                            break;
                        case "E":
                            currentJobTitle = "Professor";
                            break;
                    }
                }
                

                    int ID = dbReader.GetInt32(0);

                string? degree = null;
                if (!dbReader.IsDBNull(9))
                {
                    degree = dbReader.GetString(9);
                }

                int? supervisor = null;
                if (!dbReader.IsDBNull(10))
                {
                    supervisor = dbReader.GetInt32(10);
                }

                DateTime commencedWithInstitution= dbReader.GetDateTime(12);

                DateTime commencedCurrentPosition= dbReader.GetDateTime(13);

                ResearcherType type = ParseEnum<ResearcherType>(dbReader.GetString(1));

                ResearcherLevel? level;
                if (dbReader.IsDBNull(11))
                {
                    level = null;
                }
                else
                {
                    level = (ResearcherLevel?)ParseEnum<ResearcherLevel>(dbReader.GetString(11));
                }

                ResearcherDetailed.CampusType campus = ParseEnum<ResearcherDetailed.CampusType>(dbReader.GetString(6).Replace(' ', '_'));

                conn.Close();

                newResearcherDetailed = new ResearcherDetailed(type, campus, level, ID, nameGiven, nameFamily, title, schoolOrUnit, email, photo, currentJobTitle, degree, supervisor, commencedWithInstitution, commencedCurrentPosition);
                
            }   

            catch
            {
                Debug.WriteLine("Exception Thrown!");
            }

            finally
            {
                if (dbReader != null) { dbReader.Close(); }
                if (conn != null) { conn.Close(); }
            }

            return newResearcherDetailed;
        }

        public static ObservableCollection<PublicationBrief> publicationBriefQuery(int researcherID) 
        { // modify int values to date objects later

            ObservableCollection<PublicationBrief> newPublicationBriefArray = new ObservableCollection<PublicationBrief>();
            MySqlDataReader dbReader = null;
            List<string> publicationDOIList = new List<string>();

            try
            {
                GetConnection();
                conn.Open();
                Debug.WriteLine(conn);

                MySqlCommand getResearcherPublished = new MySqlCommand("SELECT doi FROM researcher_publication WHERE researcher_id = @newID", conn);
                getResearcherPublished.Parameters.Add("@newID", MySqlDbType.Int64);
                getResearcherPublished.Parameters["@newID"].Value = researcherID;
                dbReader = getResearcherPublished.ExecuteReader();

                while (dbReader.Read())
                {
                    publicationDOIList.Add(dbReader.GetString(0));
                }
            }

            catch
            {
                Debug.WriteLine("Exception Thrown!");
            }

            finally
            {
                //if (dbReader != null) { dbReader.Close(); }
                if (conn != null) { conn.Close(); }
            }

            try
            {
                foreach (string DOI in publicationDOIList)
                {
                    conn.Open();
                    MySqlCommand getPublicationBrief = new MySqlCommand("SELECT doi, title, year, ranking FROM publication WHERE doi = @newDOI", conn);
                    getPublicationBrief.Parameters.Add("@newDOI", MySqlDbType.VarChar);
                    getPublicationBrief.Parameters["@newDOI"].Value = DOI;
                    dbReader = getPublicationBrief.ExecuteReader();

                    while (dbReader.Read())
                    {
                        string publicationTitle = dbReader.GetString(1);
                        int publicationYear = dbReader.GetInt32(2);
                        string publicationDOI = dbReader.GetString(0);
                        string publicationRanking = dbReader.GetString(3);


                        newPublicationBriefArray.Add(new PublicationBrief(publicationTitle, publicationYear, publicationDOI, publicationRanking));
                    }
                    if(conn != null) { conn.Close(); }
                } 
            }

            catch
            {
                Debug.WriteLine("Exception Thrown!");
            }

            finally
            {
                if (dbReader != null) { dbReader.Close(); }
                if (conn != null) { conn.Close(); }
            }

            return newPublicationBriefArray;
        }

        public static ObservableCollection<PublicationDetailed> publicationDetailedQuery(string publicationDOI)
        {
            ObservableCollection<PublicationDetailed> newPublicationDetailsArray = new ObservableCollection<PublicationDetailed>();
            MySqlDataReader dbReader = null;

            try
            {
                GetConnection();
                conn.Open();
                Debug.WriteLine(conn);

                MySqlCommand getPublicationDetailed = new MySqlCommand("SELECT * FROM publication WHERE doi = @newDOI", conn);
                getPublicationDetailed.Parameters.Add("@newDOI", MySqlDbType.VarChar);
                getPublicationDetailed.Parameters["@newDOI"].Value = publicationDOI;
                dbReader = getPublicationDetailed.ExecuteReader();

                while (dbReader.Read())
                {

                    //ResearcherType researcherType = ParseEnum<ResearcherType>(dbReader.GetString(1));

                    string detailsDOI = dbReader.GetString(0);
                    string detailsTitle = dbReader.GetString(1);
                    PublicationDetailed.PublicationRanking detailsRanking = ParseEnum<PublicationDetailed.PublicationRanking>(dbReader.GetString(2));
                    string detailsAuthors = dbReader.GetString(3);
                    int detailsYear = dbReader.GetInt32(4);
                    PublicationDetailed.PublicationType detailsType = ParseEnum<PublicationDetailed.PublicationType>(dbReader.GetString(5));
                    string detailsCite = dbReader.GetString(6);
                    DateTime detailsAvailable = dbReader.GetDateTime(7);

                    newPublicationDetailsArray.Add(new PublicationDetailed(detailsType, detailsRanking, detailsDOI, detailsTitle, detailsAuthors, detailsCite, detailsYear, detailsAvailable));
                }
            }

            catch
            {
                Debug.WriteLine("Exception Thrown!");
            }

            finally
            {
                //if (dbReader != null) { dbReader.Close(); }
                if (conn != null) { conn.Close(); }
            }


            return newPublicationDetailsArray;
        }

        public static ObservableCollection<ResearcherSupervision> supervisionsQuery(int researcherID)
        {
            ObservableCollection<ResearcherSupervision> newSupervisionsArray = new ObservableCollection<ResearcherSupervision>();

            return newSupervisionsArray;
        }
        
    }
}
