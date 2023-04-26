using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    public class ResearcherListController
    {
        public int filterRange;
        public string filterName;
        public static int researcherID;
        public static List<ResearcherDetailsBrief> researcherDetailsBriefCache;
        public static List<ResearcherDetailsBrief> researcherDetailsBriefTemp;

        public static List<ResearcherBrief> applyFilters(List<ResearcherBrief> listCache, int filterRange, string filterName)
        {
            List<ResearcherBrief> listTemp = new List<ResearcherBrief>(listCache); //clones cached original list
            /*Filter implementation Here
             */ 
            return listTemp;
        }
        public static List<ResearcherBrief> populateCache(List<ResearcherBrief> ListCache)
        {

            return ListCache;
        }
        public void showResearcherDetails(int researcherID)
        {

        }

    }

public class ResearcherBriefController
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
