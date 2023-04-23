// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using static ResearcherRAP_Project.ResearcherDetailed;

namespace ResearcherRAP_Project
{
    /*ResearcherLevel and type utilized both in ResearcherDetailed and ResearcherBrief Hence is put here*/
    public enum ResearcherLevel { A, B, C, D, E };
    public enum ResearcherType { Staff, Student };

    public class ResearcherDetailed
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
        public float? performancebyPublication; //staff only (Nullable)
        public float? performancebyFunding; //staff only (Nullable)

        public DateTime commencedWithInstitution;
        public DateTime commencedCurrentPosition;
        public DateTime tenure;

        public List<PublicationBrief> publicationsCache;
        public List<PublicationBrief> publicationsTemp;

        public ResearcherDetailed(ResearcherType type, CampusType campus, ResearcherLevel level, int researcherID, string nameGiven, string nameFamily, string title, string schoolOrUnit, string email, string photo, string currentJobTitle, int publicationCount, int q1Percentage, string? degree, string? supervisor, float? threeYearAverage, float? fundingReceived, float? performancebyPublication, float? performancebyFunding, DateTime commencedWithInstitution, DateTime commencedCurrentPosition, DateTime tenure, List<PublicationBrief> publicationsCache, List<PublicationBrief> publicationsTemp)
        {
            this.type = type;
            this.campus = campus;
            this.level = level;
            this.researcherID = researcherID;
            this.nameGiven = nameGiven;
            this.nameFamily = nameFamily;
            this.title = title;
            this.schoolOrUnit = schoolOrUnit;
            this.email = email;
            this.photo = photo;
            this.currentJobTitle = currentJobTitle;
            this.publicationCount = publicationCount;
            this.q1Percentage = q1Percentage;
            this.degree = degree;
            this.supervisor = supervisor;
            this.threeYearAverage = threeYearAverage;
            this.fundingReceived = fundingReceived;
            this.performancebyPublication = performancebyPublication;
            this.performancebyFunding = performancebyFunding;
            this.commencedWithInstitution = commencedWithInstitution;
            this.commencedCurrentPosition = commencedCurrentPosition;
            this.tenure = tenure;
            this.publicationsCache = publicationsCache;
            this.publicationsTemp = publicationsTemp;
        }
    }
    public class ResearcherBrief //formerly researcherList - to implement!, is the shortform class used for list indexing to save space as we dont need to traverse and cache all of the records
    {
        public ResearcherType type;
        public ResearcherLevel level;

        public string nameGiven;
        public string nameFamily;
        public string title;
    }
    public class ResearcherDetailsBrief //used on interactiv history for staff researchers for positions held
    {
        public string staffResearcherPreviousPosition;
        public DateTime staffResearcherPositionStart;
        public DateTime staffResearcherPositionEnd;
    }
    public class PublicationDetailed
    {
        public enum PublicationType { Conference, Journal, Other };

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
    public class PublicationBrief //formerly cumulative
    {
        public string name;
        public string year;
    }

}

