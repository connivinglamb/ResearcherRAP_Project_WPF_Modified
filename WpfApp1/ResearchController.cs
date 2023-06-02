using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    public class ResearcherBriefController
    {
        public static int filterRange;
        public static string? filterName;
        public static int researcherID;

        public static List<ResearcherBrief> researcherDetailsBriefCache;
        public static ObservableCollection<ResearcherBrief> researcherDetailsBriefTemp { get; set; }

        public static void applyFilters(List<ResearcherBrief> listCache, int filterRange, string filterName)
        {
            List<ResearcherBrief> filteredList = listCache;

            switch (filterRange)
            {
                default:
                    break;
                case 1:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Student select entry).ToList<ResearcherBrief>();
                    break;
                case 2:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff select entry).ToList<ResearcherBrief>();
                    break;
                case 3:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff && entry.level == ResearcherLevel.A select entry).ToList<ResearcherBrief>();
                    break;
                case 4:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff && entry.level == ResearcherLevel.B select entry).ToList<ResearcherBrief>();
                    break;
                case 5:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff && entry.level == ResearcherLevel.C select entry).ToList<ResearcherBrief>();
                    break;
                case 6:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff && entry.level == ResearcherLevel.D select entry).ToList<ResearcherBrief>();
                    break;
                case 7:
                    filteredList = (from entry in filteredList where entry.type == ResearcherType.Staff && entry.level == ResearcherLevel.E select entry).ToList<ResearcherBrief>();
                    break;

            }

            if (!string.IsNullOrEmpty(filterName))
            {
                System.Text.RegularExpressions.Regex searchTerm = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Replace(filterName, @"[^0-9a-zA-Z]+", ""));
                filteredList = (from entry in filteredList where entry.nameGiven.Contains(filterName, StringComparison.CurrentCultureIgnoreCase) 
                || entry.nameFamily.Contains(filterName, StringComparison.CurrentCultureIgnoreCase) select entry).ToList<ResearcherBrief>();
            }

            researcherDetailsBriefTemp.Clear();
            foreach(ResearcherBrief entry in filteredList)
            {
                researcherDetailsBriefTemp.Add(entry);
            }
            
        }
        public static List<ResearcherBrief> populateCache(List<ResearcherBrief> ListCache)
        {
            ListCache = DBAdapter.ResearcherBriefQuery();
            return ListCache;
        }

        public ResearcherBriefController()
        {
            filterRange = 0;
            filterName = "";
            researcherID = 0;
            researcherDetailsBriefCache = populateCache(researcherDetailsBriefCache);
            researcherDetailsBriefTemp = new ObservableCollection<ResearcherBrief>(researcherDetailsBriefCache);
        }
        public static List<ResearcherBrief> loadResearchers()
        {
            researcherDetailsBriefCache = populateCache(researcherDetailsBriefCache);
            return researcherDetailsBriefCache;
        }

        public static ObservableCollection<ResearcherBrief> getResearcherBriefTemp() 
        {
            return researcherDetailsBriefTemp;
        }
        public void showResearcherDetails()
        {

        }

    }

    class ReportController
    {
        public void reportClipboardRetrieve(ObservableCollection<ResearcherReport> reportCacheCurrent)
        {

        }
        public ObservableCollection<ResearcherReport> reportGenerate(int performanceFilter)
        {
            ObservableCollection<ResearcherReport> newResearcherReport = new ObservableCollection<ResearcherReport>();

            return newResearcherReport;
        }

        public void reportClipboadRetrieve(ObservableCollection<ResearcherReport> reportCacheCurrent)
        {

        }
    }
    class ResearcherDetailsController
    {
        public static ResearcherDetailed ResearcherDetailsCache { get; set; }
        public static void loadResearcherDetails(int researcherID)
        {
            ResearcherDetailsCache = DBAdapter.researcherDetailedQuery(researcherID);
        }
        public static void userViewsPublications(int researcherID, int publicationID)
        {
            
        }

        public void userViewsCumulativeCount(int researcherID)
        {

        }

        public void userExpandsSupervisions(int researcherID)
        {
            
        }

        public static ResearcherDetailed GetResearcherDetails()
        {
            return ResearcherDetailsCache;
        }
    }

    public static class PublicationsController
    {
        public static ObservableCollection<PublicationBrief> loadPublications(int researcherID)
        {
            return DBAdapter.publicationBriefQuery(researcherID);
        }

    }

    class PublicationDetailsController
    {
        public static PublicationDetailed publicationDetailsCache { get; set; }

        public static PublicationDetailed loadPublication(string publicationID)
        {
            publicationDetailsCache = DBAdapter.publicationDetailedQuery(publicationID);
            return publicationDetailsCache;
        }
    }

    static class SupervisionsController
    {
        public static ObservableCollection<ResearcherSupervision> loadSupervisions(int researcherID)
        {
            return DBAdapter.supervisionsQuery(researcherID);
        }
    }

    class ResearcherCumulativeCountController
    {
        public void loadResearcherCumulativeCount(int researcherID)
        {
            
        }
    }
}
