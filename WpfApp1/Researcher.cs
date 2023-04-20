// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace ResearcherRAP_Project
{

    class Researcher
    {
        public int researcherID;
        public string name;
        public string title;
        public string schoolOrUnit;
        public string campus;
        public string email;
        public string photo;
        public string currentJobTitle;
        public DateTime commencedWithInstitution;
        public DateTime commencedCurrentPosition;
        public DateTime tenure;
        public int publicationCount;
        public int q1Percentage;
        public List<Publication> publicationsCache;
        public List<Publication> publicationsTemp;
    }
    class PublicationDetails
    {
        public string doi;
        public string authors;
        public DateTime publicationYear;
        public string ranking;
        public string type;
        public string citeAs;
        public DateTime availabilityDate;
        public int age;
    }
    class Publication
    {
        public string name;
        public string year;
    }
}

