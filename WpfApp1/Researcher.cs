// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using static ResearcherRAP_Project.ResearcherDetailed;

namespace ResearcherRAP_Project
{
    /*ResearcherLeven and type utilized both in ResearcherDetailed and ResearcherBrief Hence is put here*/
    public enum ResearcherLevel { A, B, C, D, E };
    public enum ResearcherType { Staff, Student };

    class ResearcherDetailed
    {
        
        public enum CampusType { Hobart, Launceston, Cradle_Coast };
        
        public ResearcherType type;
        public CampusType campus;
        public ResearcherLevel level;

        public int researcherID;
        public string nameGiven;
        public string nameFamily;
        public string title;
        public string schoolOrUnit;
        public string email;
        public string photo;
        public string currentJobTitle;
        public int publicationCount;
        public int q1Percentage;

        public string? degree; //students only (Nullable)
        public string? supervisor; //students only (Nullable)
        public float? threeYearAverage; //staff only (Nullable)
        public float? fundingReceived; //staff only (Nullable)
        public float? performancebyPublication;
        public float? performancebyFunding;

        public DateTime commencedWithInstitution;
        public DateTime commencedCurrentPosition;
        public DateTime tenure;

        public List<PublicationBrief> publicationsCache;
        public List<PublicationBrief> publicationsTemp;
    }
    class ResearcherBrief //formerly researcherList - to implement!, is the shortform class used for list indexing to save space as we dont need to traverse and cache all of the records
    {
        public ResearcherType type;
        public ResearcherLevel level;

        public string nameGiven;
        public string nameFamily;
        public string title;
    }
    class PublicationDetailed
    {
        public enum PublicationType { Conference, Journal, Other};

        public PublicationType type;

        public string doi;
        public string title;
        public string authors;
        public string ranking;
        public string citeAs;
        public int age;

        public DateTime publicationYear;
        public DateTime availabilityDate;
        
    }
    class PublicationBrief //formerly cumulative
    {
        public string name;
        public string year;
    }
}

