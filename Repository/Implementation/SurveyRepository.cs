using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Interface;

namespace Survey_Feedback.Repository.Implementation
{
    public class SurveyRepository : ISurveyRepository
    {
        public Survey AddSurvey(Survey survey)
        {
            SurveyContext.Surveys.Add(survey);
            using (var str = new StreamWriter(SurveyContext.SurveyFile, true))
            {
                str.WriteLine(survey.ToString());
            }
            return survey;
        }

        public ICollection<Survey> GetAllSurvey()
        {
            return SurveyContext.Surveys;
        }

        public ICollection<Survey> GetSurveyByUser()
        {
            return SurveyContext.Surveys;
        }

        public bool IsDelete(string title)
        {
            foreach (var survey in SurveyContext.Surveys)
            {
                if (survey.Title == title)
                {
                    SurveyContext.Surveys.Remove(survey);
                    return true;
                }
            }
            return false;
        }

        public void ReadAllFromFIle()
        {
            var survey = File.ReadAllLines(SurveyContext.SurveyFile);
            foreach (var item in survey)
            {
                var surveyLine = Survey.ToSurveys(item);
                SurveyContext.Surveys.Add(surveyLine);
            }
        }
        public void RefreshFile()
        {
            using (var str = new StreamWriter(SurveyContext.SurveyFile, false))
            {
                foreach (var item in SurveyContext.Surveys)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

    }
}