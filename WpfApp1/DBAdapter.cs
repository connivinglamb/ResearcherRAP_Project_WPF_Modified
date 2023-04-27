using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    class DBAdapter
    {
        public static List<ResearcherBrief> researcherBriefQuery()
        {
            List<ResearcherBrief> newResearcherBriefArray = new List<ResearcherBrief>();
            newResearcherBriefArray.Add(new ResearcherBrief(ResearcherType.Staff, ResearcherLevel.A, "David", "Herbert","Dr",0));
            newResearcherBriefArray.Add(new ResearcherBrief(ResearcherType.Staff, ResearcherLevel.C, "Brian", "Stuart","Mr",1));
            newResearcherBriefArray.Add(new ResearcherBrief(ResearcherType.Student, ResearcherLevel.D, "Maria", "Kelly","Ms",2));
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
