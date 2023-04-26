using System;
using System.Collections.Generic;
using System.Linq;

namespace ResearcherRAP_Project
{
    class RAP
    {
        static void MainTemp(string[] args) // renamed as main is called later in the application document for the WPF instantiation
        {
            List<PublicationBrief> testMe = DBAdapter.publicationBriefQuery();
            Console.WriteLine("test\n");
            int i = 0; // 0 initialized for publication increment

            foreach (PublicationBrief publication in testMe)
            {
                Console.WriteLine(i + " " + publication.publicationName + " " + publication.publicationYear);
                i++;
            }

            //Console.WriteLine("now printing inverted list"); - 
            Console.WriteLine("\n");

            //LINQ Query, seperate to SQL DBAdapter Return
            var query1 = from PublicationBrief publication in testMe
                         where publication.publicationName != "applied logistics"
                         select publication;

            //LINQ Query iteration
            foreach (PublicationBrief x in query1) // -- x in this case refers to the publication object/element reference.
            {
                Console.WriteLine(x.publicationName + " " + x.publicationYear);
            }

            //To Pause Console Readout for testing
            Console.ReadLine();
        }
    }

}
