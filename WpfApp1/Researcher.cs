// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static ResearcherRAP_Project.ResearcherDetailed;
using System.Runtime.CompilerServices;

namespace ResearcherRAP_Project
{
    /*ResearcherLevel and type utilized both in ResearcherDetailed and ResearcherBrief Hence is put here*/
    public enum ResearcherLevel { A, B, C, D, E };
    public enum ResearcherType { Staff, Student };

    public static class GlobalVariables
    {
        public static int GlobalResearcherID;
    }

    public class ResearcherBrief //formerly researcherList - to implement!, is the shortform class used for list indexing to save space as we dont need to traverse and cache all of the records
    {
        public ResearcherType type;
        public ResearcherLevel? level;

        public string nameGiven { get; set; }
        public string nameFamily { get; set; }
        public string title { get; set; }
        public int researcherID;

        public ResearcherBrief(ResearcherType type, ResearcherLevel? level, string nameGiven, string nameFamily, string title, int researcherID)
        {
            this.type = type;
            this.level = level;
            this.nameGiven = nameGiven;
            this.nameFamily = nameFamily;
            this.title = title;
            this.researcherID = researcherID;
        }

        public override string ToString()
        {
            string outputString = string.Format("{0} {1} ({2}) {3}", this.nameGiven, this.nameFamily, this.title, this.researcherID);
            Console.Write(outputString);
            return outputString;
        }
    }
    public class ResearcherDetailed
    {
        
        public enum CampusType { Hobart, Launceston, Cradle_Coast };
        
        public ResearcherType type { get; set; }
        public CampusType campus { get; set; }
        public ResearcherLevel? level { get; set; }

        public int researcherID { get; set; }
        public string nameGiven { get; set; }
        public string nameFamily { get; set; }
        public string title { get; set; }
        public string schoolOrUnit { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string currentJobTitle { get; set; }
        public int publicationCount { get; set; }
        public double q1Percentage { get; set; }

        public string? degree { get; set; } //students only (Nullable)
        public int? supervisor { get; set; } //students only (Nullable)

        public string? supervisorName
        {
            get
            {
                if (supervisor == null)
                    return null;
                else
                {
                    string? name = null;
                    foreach (var researcher in ResearcherBriefController.researcherDetailsBriefCache)
                    {
                        if (researcher.researcherID == supervisor)
                            name = researcher.ToString();
                    }
                    return name;
                }
            }
        }

        public ObservableCollection<ResearcherSupervision>? supervisions { get; set; } //staff only (Nullable)
        public int? supervisionsCount { get; set; } //staff only nullable extension of supervisions
        public double? threeYearAverage { get; set; } //staff only (Nullable)
        public double? fundingReceived { get; set; } //staff only (Nullable)
        public double? performancebyPublication { get; set; } //staff only (Nullable)
        public double? performancebyFunding { get; set; } //staff only (Nullable)
        public double? performance { get; set; }


        public DateTime commencedWithInstitution { get; set; }
        public DateTime commencedCurrentPosition { get; set; }
        public double tenure { get; set; }

        public ObservableCollection<PublicationBrief> hasPublications { get; set; }

        public ResearcherDetailed(ResearcherType type, CampusType campus, ResearcherLevel? level, int researcherID, string nameGiven, string nameFamily, string title, string schoolOrUnit, string email, string photo, string currentJobTitle, string? degree, int? supervisor, DateTime commencedWithInstitution, DateTime commencedCurrentPosition)
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
            //this.publicationCount = publicationCount;
            //this.q1Percentage = q1Percentage;
            this.degree = degree;
            this.supervisor = supervisor;

            //this.threeYearAverage = threeYearAverage; //more work needs to be done here for null values in constructor
            //this.fundingReceived = fundingReceived;
            //this.performancebyPublication = performancebyPublication;
            //this.performancebyFunding = performancebyFunding;

            this.commencedWithInstitution = commencedWithInstitution;
            this.commencedCurrentPosition = commencedCurrentPosition;
            tenure = Math.Round(DateTime.Now.Subtract(commencedWithInstitution).TotalDays/365.2425, 2);

            hasPublications = PublicationsController.loadPublications(researcherID);
            publicationCount = hasPublications.Count;

            double rankingCount = 0;
            double threeYearCount = 0;
            foreach (var publication in hasPublications)
            {
                if (publication.publicationRanking.Equals("Q1"))
                {
                    rankingCount++;
                }

                if (publication.publicationYear < DateTime.Now.Year && publication.publicationYear > (DateTime.Now.Year - 4))
                {
                    threeYearCount++;
                }
            }
            q1Percentage = rankingCount / publicationCount * 100;
            if (type == ResearcherType.Staff)
            {
                threeYearAverage = threeYearCount / 3;
                fundingReceived = (double)XMLAdaptor.getFunding(researcherID);
                performancebyPublication = Math.Round(publicationCount / Math.Round(tenure), 2);
                performancebyFunding = Math.Round((double)fundingReceived / Math.Round(tenure));
                supervisions = SupervisionsController.loadSupervisions(researcherID);
                supervisionsCount = supervisions.Count;

                double expected = 1.5;
                switch (level)
                {
                    case ResearcherLevel.A:
                        expected = 1.5;
                        break;
                    case ResearcherLevel.B:
                        expected = 3;
                        break;
                    case ResearcherLevel.C:
                        expected = 6;
                        break;
                    case ResearcherLevel.D:
                        expected = 9.6;
                        break;
                    case ResearcherLevel.E:
                        expected = 12;
                        break;
                }
                performance = Math.Round((double)threeYearAverage / expected * 100, 1);

                threeYearAverage = Math.Round((double)threeYearAverage, 2);

            } else
            {
                threeYearAverage = null;
                fundingReceived = null;
                performancebyPublication = null;
                performancebyFunding = null;
                performance = null;
            }

        }
    }
    /*
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
    */
    public class PublicationBrief //formerly cumulative
    {
        public string publicationName { get; set; }
        public int publicationYear { get; set; }
        public string publicationDOI { get; set; }
        public string publicationRanking { get; set; }

        public PublicationBrief(string name, int year, string doi, string ranking)
        {
            this.publicationName = name;
            this.publicationYear = year;
            this.publicationDOI = doi;
            this.publicationRanking = ranking;
        }

        public override string ToString()
        {
            string outputString = string.Format("{0} {1} {2} @{3}", this.publicationName, this.publicationYear, this.publicationRanking, this.publicationDOI);
            Console.Write(outputString);
            return outputString;
        }
    }
    public class PublicationDetailed
    {
        public enum PublicationType { Conference, Journal, Other }
        public enum PublicationRanking { Q1,  Q2, Q3, Q4 };

        public PublicationType type { get; set; }
        public PublicationRanking ranking { get; set; }
        public string doi { get; set; }
        public string title { get; set; }
        public string authors { get; set; }
        public string citeAs { get; set; }
        public int age { get; set; }

        public int year { get; set; }
        public DateTime availabilityDate { get; set; }

        public int Age()
        {
            return DateTime.Now.Year - year;
        }

        public PublicationDetailed(PublicationType type, PublicationRanking ranking, string doi, string title, string authors, string citeAs, int year, DateTime availabilityDate)
        {
            this.type = type;
            this.ranking = ranking;
            this.doi = doi;
            this.title = title;
            this.authors = authors;
            this.citeAs = citeAs;
            this.year = year;
            this.availabilityDate = availabilityDate;
            this.Age();
        }
    }

    public class ResearcherSupervision
    {
        public string name;

        public ResearcherSupervision(string name)
        {
            this.name = name;
        }
    }
    
    /*
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
    */

}

