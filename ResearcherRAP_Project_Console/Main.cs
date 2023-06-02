using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace ResearcherRAP_Project_Console
{
        /*ResearcherLevel and type utilized both in ResearcherDetailed and ResearcherBrief Hence is put here*/
    public enum ResearcherLevel { A, B, C, D, E };
    public enum ResearcherType { Staff, Student };  

    public class ResearcherBrief //formerly researcherList - to implement!, is the shortform class used for list indexing to save space as we dont need to traverse and cache all of the records
    {
        public ResearcherType type;
        public ResearcherLevel level;

        public string nameGiven;
        public string nameFamily;
        public string title;
        public int  researcherID;

        public ResearcherBrief(ResearcherType type, ResearcherLevel level, string nameGiven, string nameFamily, string title, int researcherID)
        {
            this.type = type;
            this.level = level;
            this.nameGiven = nameGiven;
            this.nameFamily = nameFamily;
            this.title = title;
            this.researcherID = researcherID;
        }

        public string ToString()
        {
            string outputString = string.Format("{0} {1} ({2})", this.nameGiven, this.nameFamily, this.title);
            return outputString;
        }
    }
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

        public List<ResearcherDetailed>? supervisions; //staff only (Nullable)
        public float? threeYearAverage; //staff only (Nullable)
        public float? fundingReceived; //staff only (Nullable)
        public float? performancebyPublication; //staff only (Nullable)
        public float? performancebyFunding; //staff only (Nullable)

        public DateTime commencedWithInstitution;
        public DateTime commencedCurrentPosition;
        public DateTime tenure;

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

            this.threeYearAverage = threeYearAverage; //more work needs to be done here for null values in constructor
            this.fundingReceived = fundingReceived;
            this.performancebyPublication = performancebyPublication;
            this.performancebyFunding = performancebyFunding;

            this.commencedWithInstitution = commencedWithInstitution;
            this.commencedCurrentPosition = commencedCurrentPosition;
            this.tenure = tenure;
        }
    }
    public class ResearcherDetailsBrief //used on interactiv history for staff researchers for positions held
    {
        public string staffResearcherPreviousPosition;
        public DateTime staffResearcherPositionStart;
        public DateTime staffResearcherPositionEnd;

        public ResearcherDetailsBrief(string previousPosition, DateTime startDate, DateTime endDate)
        {
            this.staffResearcherPreviousPosition = previousPosition;
            this.staffResearcherPositionStart = startDate;
            this.staffResearcherPositionEnd = endDate;
        }
        public void ToString()
        {
            //To string function for researcherDetails brief in format : position, start - end
        }
    }
    public class PublicationBrief //formerly cumulative
    {
        public string publicationName;
        public string publicationYear;

        public PublicationBrief(string name, string year)
        {
            this.publicationName = name;
            this.publicationYear = year;
        }
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

        public int year;
        public DateTime availabilityDate;

        public int Age()
        {
            return DateTime.Now.Year - year;
        }

        public PublicationDetailed(PublicationType type, string doi, string title, string authors, string ranking, string citeAs, int year, DateTime availabilityDate)
        {
            this.type = type;
            this.doi = doi;
            this.title = title;
            this.authors = authors;
            this.ranking = ranking;
            this.citeAs = citeAs;
            this.year = year;
            this.availabilityDate = availabilityDate;
            this.Age();
        }
    }

    public class ResearcherSupervision
    {
        public int id;
        public string name;

        public ResearcherSupervision(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    
    public class ResearcherReport
    {
        public enum ReportGrade { poor, below_expectations, meeting_minimum, star_performer }
        public ReportGrade grade;
        public string researcherNameFirst;
        public string researcherNameLast;

        public ResearcherReport(int gradeValue, string first, string last)
        {
            grade = new ReportGrade(); //instansiate grade 

            switch (gradeValue)
            {
                default:
                    throw new ArgumentException("Error: invalid Researcher Report Grade! closing now");
                    break;

                case <= 70:
                    this.grade = ReportGrade.poor; 
                    break;

                case > 70 and <= 110:
                    this.grade = ReportGrade.below_expectations;
                    break;

                case > 110 and < 200:
                    this.grade = ReportGrade.meeting_minimum;
                    break;

                case >= 200:
                    this.grade = ReportGrade.star_performer;
                    break;
            }

            try
            {
                researcherNameFirst = first;
                researcherNameLast = last;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error: researcher Name values invalid");
            }
        }
    }

}