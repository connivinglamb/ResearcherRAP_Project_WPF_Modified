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
        public void reportClipboardRetrieve(List<ResearcherReport> reportCacheCurrent)
        {

        }
        public List<ResearcherReport> reportGenerate(int performanceFilter)
        {
            List<ResearcherReport> newResearcherReport = new List<ResearcherReport>();

            return newResearcherReport;
        }

        public void reportClipboadRetrieve(List<ResearcherReport> reportCacheCurrent)
        {

        }
    }
    class ResearcherDetailsController
    {
        public void loadResearcherDetails(int researcherID)
        {
            
        }
        public void userViewsPublications(int researcherID, int publicaitonID)
        {
            
        }

        public void userViewsCumulativeCount(int researcherID)
        {

        }

        public void userExpandsSupervisions(int researcherID)
        {
            
        }
    }

    class PublicationsController
    {
        public Boolean publicationsInverted;
        public DateTime publicationsYearMin;
        public DateTime publicationsYearMax;

        public void loadPublications(int researcherID)
        {
            
        }

        public void publicationsFilter(int yearMin, int yearMax)
        {
            //convert userinput to DateTime format
            DateTime newYearMin = DateTime.Parse(yearMin.ToString());
            DateTime newYearMax = DateTime.Parse(yearMax.ToString());


        }
    }

    class PublicationDetailsController
    {
        public List<PublicationDetailed> loadPublication(int researcherID, int publicationID)
        {
            List<PublicationDetailed> newPublicationDetailed = new List<PublicationDetailed>();

            return newPublicationDetailed;
        }
    }

    class SupervisionsController
    {
        public void loadSupervisions(int researcherID)
        {
            
        }
    }

    class ResearcherCumulativeCountController
    {
        public void loadResearcherCumulativeCount(int researcherID)
        {
            
        }
    }
}
