using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    class DBAdapter
    {
        public static List<ResearcherDetailed> researcherDetailsQuery(int researcherID) {
            List<ResearcherDetailed> newResearcherDetailedArray = new List<ResearcherDetailed>();
            return newResearcherDetailedArray;
        }
        public static List<ResearcherDetailed> researcherDetailsQuery(int researcherID)
        {
            List<ResearcherDetailed> newResearcherDetailedArray = new List<ResearcherDetailed>();
            return newResearcherDetailedArray;
        }
        public static List<PublicationBrief> publicationQuery(int researcherID) { // modify int values to date objects later
            

            List<PublicationBrief> newPublicationArray = new List<PublicationBrief>(); //establishes publication array instantiation in memory
                newPublicationArray.Add(new PublicationBrief { name = "applied logistics", year = "1999"}); // pretend if this is a SELECT * FROM Retrieval query and iteration from a FOR loop
                newPublicationArray.Add(new PublicationBrief { name = "computation heiarchy", year = "1998" });
            return newPublicationArray;
        }
        
    }
}
