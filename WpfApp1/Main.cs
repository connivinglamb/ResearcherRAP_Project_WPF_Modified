using System;
using System.Collections.Generic;
using System.Linq;

namespace ResearcherRAP_Project
{
    class RAP
    {
        static void MainTemp(string[] args) // renamed as main is called later in the application document for the WPF instantiation
        {
            List<Publication> testMe = DBAdapter.publicationQuery(1);
            Console.WriteLine("test\n");
            int i = 0; // 0 initialized for publication increment

            foreach (Publication publication in testMe)
            {
                Console.WriteLine(i + " " + publication.name + " " + publication.year);
                i++;
            }

            //Console.WriteLine("now printing inverted list"); - 
            Console.WriteLine("\n");

            //LINQ Query, seperate to SQL DBAdapter Return
            var query1 = from Publication publication in testMe
                         where publication.name != "applied logistics"
                         select publication;

            //LINQ Query iteration
            foreach (Publication x in query1) // -- x in this case refers to the publication object/element reference.
            {
                Console.WriteLine(x.name + " " + x.year);
            }

            //To Pause Console Readout for testing
            Console.ReadLine();
        }
    }

}
