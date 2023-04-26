﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    class DBAdapter
    {
        public static List<ResearcherBrief> researcherBriefQuery(int researcherID)
        {
            List<ResearcherBrief> newResearcherBriefArray = new List<ResearcherBrief>();
            return newResearcherBriefArray;
        }
        public static List<ResearcherDetailed> researcherDetailedQuery(int researcherID) {
            List<ResearcherDetailed> newResearcherDetailedArray = new List<ResearcherDetailed>();
            return newResearcherDetailedArray;
        }
        public static List<PublicationBrief> publicationBriefQuery(int researcherID)
        {
            List<PublicationBrief> newPublicationBriefArray = new List<PublicationBrief>(); //establishes publication array instantiation in memory
            newPublicationBriefArray.Add(new PublicationBrief { name = "applied logistics", year = "1999" }); // pretend if this is a SELECT * FROM Retrieval query and iteration from a FOR loop
            newPublicationBriefArray.Add(new PublicationBrief { name = "computation heiarchy", year = "1998" });
            return newPublicationBriefArray;
        }
        public static List<PublicationDetailed> publicationDetailedQuery(int researcherID) { // modify int values to date objects later



            List<PublicationDetailed> newPublicationArray = new List<PublicationDetailed>();
            return newPublicationArray;
        }
        public static List<PublicationDetailed> 
        
    }
}
