using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    public class ResearcherBriefController
    {
        public static int filterRange;
        public static string filterName;
        public static int? researcherID;

        public static List<ResearcherBrief> researcherDetailsBriefCache;
        public static List<ResearcherBrief> researcherDetailsBriefTemp;

        public static List<ResearcherBrief> applyFilters(List<ResearcherBrief> listCache, int filterRange, string filterName)
        {
            List<ResearcherBrief> listTemp = new List<ResearcherBrief>(listCache); //clones cached original list
            /*Filter implementation Here
             */ 
            return listTemp;
        }
        public static List<ResearcherBrief> populateCache(List<ResearcherBrief> ListCache)
        {
            ListCache = DBAdapter.researcherBriefQuery();
            return ListCache;
        }
        public ResearcherBriefController()
        {
            filterRange = 0;
            filterName = "";
            researcherID = 0;
            researcherDetailsBriefCache = populateCache(researcherDetailsBriefCache);
            researcherDetailsBriefTemp = researcherDetailsBriefCache;
        }
        public static List<ResearcherBrief> loadResearchers()
        {
            return researcherDetailsBriefTemp;
        }
        public void showResearcherDetails()
        {

        }

    }

public class ResearcherDetailedController
    {
        private static int researcherID;
        public void userViewsPublications(int researcherID)
        {

        }
        public void userViewsCumulativeCount(int researcherID)
        {

        }
        public void userViewsExpandsSupervisions(int researcherID)
        {

        }
        public void loadResearcherDetails(int researcherID)
        {

        }
    }
    class ReportController
    {

    }
    class ResearcherDetailsController
    {

    }

    class PublicationsController
    {

    }

    class PublicationDetailsController
    {

    }

    class SupervisionsController
    {

    }

    class ResearcherCumulativeCountController
    {

    }
}
