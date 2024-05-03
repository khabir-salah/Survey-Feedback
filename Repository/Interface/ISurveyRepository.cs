using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.Repository.Interface
{
    public interface ISurveyRepository
    {
        public Survey AddSurvey(Survey survey);
        public ICollection<Survey> GetAllSurvey();
        public ICollection<Survey> GetSurveyByUser();
        void ReadAllFromFIle();
        void RefreshFile();
        bool IsDelete(string title);

        

    }
}