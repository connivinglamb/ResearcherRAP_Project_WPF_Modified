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
        public void loadResearcherDetails(int researcherID)
        {
            
        }
        public void userViewsPublications(int researcherID, int publicationID)
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
        public ObservableCollection<PublicationDetailed> loadPublication(int researcherID, int publicationID)
        {
            ObservableCollection<PublicationDetailed> newPublicationDetailed = new ObservableCollection<PublicationDetailed>();
            //newPublicationDetailed.Add( DBAdapter.publicationBriefQeuery(publicationID));
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
