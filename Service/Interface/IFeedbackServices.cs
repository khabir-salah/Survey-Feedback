using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.surveyservices.Interface
{
    public interface IFeedbackServices
    {
        public void GiveFeedback(string title, string email);

        public bool CheckIfFeedbackExist(string title, string email);

        public List<Feedback> GetFeedbacks(string title);
       
        void UpDateList();

        void Refresh();

    }
}