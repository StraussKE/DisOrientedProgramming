using System;
namespace DisOrientedProgramming.Models
{
    public class SurveyModel
    {
        public Guid     SurveyModelId   { get; set; }

        // Currently not in use. Will be implemented when site is able to recognize user (currently
        // logged in) who is filling out the survey. 
        //public AppUser  User            { get; set; }

        public string   Question1       { get; set; }

        public string   Question2       { get; set; }

        public int      Question3       { get; set; }

        public int      Question4       { get; set; }

        // The below is no longer needed because storing derivable data is bad!
        //public int      SumOfQ3Answers  { get; set; }

        //public int      SumOfQ4Answers  { get; set; }

        //public int      TotalNumOfQ3s   { get; set; } 

        //public int      TotalNumOfQ4s   { get; set; }

        //public double   AverageValOfQ3s { get; set; }

        //public double   AverageValOfQ4s { get; set; }


    }//End Class 
}//End Namespace 
