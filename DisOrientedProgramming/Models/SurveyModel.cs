using System;
namespace DisOrientedProgramming.Models
{
    public class SurveyModel
    {
        public Guid     SurveyModelId   { get; set; }

        public AppUser  User            { get; set; }

        public string   Question1       { get; set; }

        public string   Question2       { get; set; }

        public int      Question3       { get; set; }

        public int      Question4       { get; set; }

        public int      SumOfQ3Answers  { get; set; }

        public int      SumOfQ4Answers  { get; set; }

        public int      TotalNumOfQ3s   { get; set; } 

        public int      TotalNumOfQ4s   { get; set; }

        public double   AverageValOfQ3s { get; set; }

        public double   AverageValOfQ4s { get; set; }



    }//End Class 
}//End Namespace 
