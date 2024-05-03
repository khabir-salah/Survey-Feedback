using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.surveyservices.Interface
{
    public interface ISurveyServices
    {
        public Survey CreatSurvey(string title, List<string> question);


        public Survey GetSurvey(string title);


        void Refresh();

        bool IsSurveyTitleExist(string title);
        

        bool IsDelete(string title);


        // public Survey GetSurvey(string title);


        public ICollection<Survey> GetSurveysByUser();


        public ICollection<Survey> GetAllDeniedSurvey();

        public ICollection<Survey> GetDeniedSurveyByClient(string email);


        public ICollection<Survey> GetApprovedSurveyByClient(string email);

        public ICollection<Survey> GetPendingSurveyByClient(string email);


        public ICollection<Survey> ViewAllApprovedSurvey();

        public ICollection<Survey> GetAllPendingSurvey();

        void UpDateList();
    }
}