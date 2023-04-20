using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearcherRAP_Project
{
    class DBAdapter
    {
        public static List<Publication> publicationQuery(int researcherID) { // modify int values to date objects later
            

            List<Publication> newPublicationArray = new List<Publication>(); //establishes publication array instantiation in memory
                newPublicationArray.Add(new Publication { name = "applied logistics", year = "1999"}); // pretend if this is a SELECT * FROM Retrieval query and iteration from a FOR loop
                newPublicationArray.Add(new Publication { name = "computation heiarchy", year = "1998" });
            return newPublicationArray;
        }

    }
}
