using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.surveyservices.Implementation;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback
{
    public class startup
    {
        IUserService userService = new UserServices();
        ISurveyServices surveyServices = new SurveyServices();
        IFeedbackServices feedbackServices = new FeedbackServices();
        IUnRegisteredUserServices unRegisteredUserServices = new UnRegisteredServices();
        public void Create()
        {
            if (!Directory.Exists("SurveyApp"))
                Directory.CreateDirectory("SurveyApp");

            var SurveyFile = Path.Combine("SurveyApp", "Surveys.txt");
            if (!File.Exists(SurveyFile))
                File.Create(SurveyFile);
            else surveyServices.UpDateList();

            var FeedbackFile = Path.Combine("SurveyApp", "Feedbacks.txt");
            if (!File.Exists(FeedbackFile)) File.Create(FeedbackFile);
            else feedbackServices.UpDateList();


            var UnRegisteredUserFile = Path.Combine("SurveyApp", "unRegisteredUsers.txt");
            if (!File.Exists(UnRegisteredUserFile)) File.Create(UnRegisteredUserFile);
            else unRegisteredUserServices.UpDateList();


            var UserFile = Path.Combine("SurveyApp", "RegisteredUsers.txt");
            if (!File.Exists(UserFile)) File.Create(UserFile);
            else userService.UpDateList();

        }
    }
}