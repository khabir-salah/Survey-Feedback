using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Models.Enum;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback.surveyservices.Implementation
{
    public class SurveyServices : ISurveyServices
    {
        ISurveyRepository surveyRepo = new SurveyRepository();

        public Survey CreatSurvey(string title, List<string> question)
        {
            var checkTitle = IsSurveyTitleExist(title);
            if (checkTitle)
            {
                return null;
            }
            Survey survey = new Survey(title, question);
            surveyRepo.AddSurvey(survey);
            return survey;
        }


        public Survey GetSurvey(string title)
        {
           foreach (var item in surveyRepo.GetAllSurvey())
        {
            if(item.Title.ToLower() == title.ToLower())
            {
                return item;
            }
        }
        return null;
        }

        public ICollection<Survey> GetAllDeniedSurvey()
        {
             var deniedSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.denied)
            {
                deniedSurvey.Add(survey);
            }
        }
        return deniedSurvey;

        }

        public ICollection<Survey> GetAllPendingSurvey()
        {
            var pendingSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.pending)
            {
                pendingSurvey.Add(survey);
            }
        }
        return pendingSurvey;
        }

        public ICollection<Survey> GetApprovedSurveyByClient(string email)
        {
            var approvedSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.Approved && survey.UserEmail == email)
            {
                approvedSurvey.Add(survey);
            }
        }
        return approvedSurvey;
        }

        public ICollection<Survey> GetDeniedSurveyByClient(string email)
        {
            var deniedSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.denied && survey.UserEmail == email)
            {
                deniedSurvey.Add(survey);
            }
        }
        return deniedSurvey;
        }

        public ICollection<Survey> GetPendingSurveyByClient(string email)
        {
            var approvedSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.pending && survey.UserEmail == email)
            {
                approvedSurvey.Add(survey);
            }
        }
        return approvedSurvey;
        }

        // public Survey GetSurvey(string title)
        // {
        //     foreach (var survey in surveyRepo.GetAllSurvey())
        //     {
        //         if (survey.Title == title)
        //         {
        //             return survey;
        //         }
        //     }
        //     return null;
        //     // var checkTitle = surveyRepo.GetAllSurvey().Where(t => t.Title.ToLower() == title.ToLower());
        //     // if (!checkTitle.Any())
        //     // {
        //     //     return null;
        //     // }
        //     // return checkTitle;
        // }

        public ICollection<Survey> GetSurveysByUser()
        {
            var survey = new List<Survey>();
        foreach (var item in surveyRepo.GetAllSurvey())
        {
            if(item.UserEmail == User.LoggedInUser.Email)
            {
                survey.Add(item);
            }
        }
        return survey;
        }

        public bool IsSurveyTitleExist(string title)
        {
            var isExist = GetSurvey(title);
            if (isExist == null)
            {
                return false;
            }
            else return true;
        }

        public ICollection<Survey> ViewAllApprovedSurvey()
        {
             var approvedSurvey = new List<Survey>();
        foreach(var survey in surveyRepo.GetAllSurvey())
        {
            if(survey.Status == Status.Approved)
            {
                approvedSurvey.Add(survey);
            }
        }
        return approvedSurvey;
        }

        public void UpDateList()
        {
            surveyRepo.ReadAllFromFIle();
        }

        public void Refresh()
        {
            surveyRepo.RefreshFile();
        }

        public bool IsDelete(string title)
        {
            return surveyRepo.IsDelete(title);
        }
    }
}