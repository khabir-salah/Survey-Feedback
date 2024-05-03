using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback.surveyservices.Implementation
{
    public class FeedbackServices : IFeedbackServices
    {
        IFeedbackRepository feedbackRepo = new FeedbackRepository();
        ISurveyServices surveyservice = new SurveyServices();

        public bool CheckIfFeedbackExist(string title, string email)
        {
            var checkFeedback = feedbackRepo.GetFeedbacks().Any(f => f.SurveyTitle.Equals(title, StringComparison.OrdinalIgnoreCase) && f.UserEmail == email);
            return checkFeedback;
        }

        public List<Feedback> GetFeedbacks(string title)
        {
            var feedbacks = new List<Feedback>();
            foreach (var feedback in feedbackRepo.GetFeedbacks())
            {
                if (feedback.SurveyTitle.ToLower() == title.ToLower())
                {
                    feedbacks.Add(feedback);
                }
            }
            return feedbacks;
        }


        public void GiveFeedback(string title, string email)
        {
            var isSurveyExist = surveyservice.IsSurveyTitleExist(title);
            if (isSurveyExist)
            {
                var checkFeedback = CheckIfFeedbackExist(title, email);
                if (checkFeedback)
                {
                    Console.WriteLine("user already gave feedback");
                    return;
                }
                var survey = surveyservice.GetSurvey(title);

                var feedbacks = new List<string>();
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                    var feedback = Console.ReadLine();
                    feedbacks.Add(feedback);
                }

                var response = new Feedback(email, title, feedbacks);
                feedbackRepo.AddFeedback(response);

            }
        }

        

        public void Refresh()
        {
            feedbackRepo.RefreshFile();
        }

        public void UpDateList()
        {
            feedbackRepo.ReadAllFromFIle();
        }
    }
}