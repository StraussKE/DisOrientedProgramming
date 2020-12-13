using System;
namespace DisOrientedProgramming.Models
{
    public class SurveyModel
    {
        public Guid SurveyModelId { get; set; }

        public AppUser User { get; set; }

        public string Question1 { get; set; }

        public string Question2 { get; set; }

        public int Question3 { get; set; }

        public int Question4 { get; set; }



    }//End Class 
}//End Namespace 
