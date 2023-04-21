using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    public static class ResearcherListController
    {
        public int filterRange;
        public string filterName;
        public int researcherID;

        public static List<ResearcherBrief> applyFilters(List<ResearcherBrief> temporaryList, int filterRange, string filterName)
        {
            return temporaryList;
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
