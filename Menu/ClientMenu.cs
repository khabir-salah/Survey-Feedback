using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.surveyservices.Implementation;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback.Menu
{
    public class ClientMenu
    {
        ISurveyServices  surveyServices = new SurveyServices();
        IFeedbackServices feedbackLogic = new FeedbackServices();
        MainMenu mainMenu = new MainMenu();
        ISurveyRepository adminLogic = new SurveyRepository();

        public void Clientmen()
        {
            Console.WriteLine("Enter\n1. To create survey \n2. To view survey by status\n3. To view survey feedback\n4. To exist");
            int choice = 5;
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                choice = num;
            }
            switch (choice)
            {
                case 1:
                    CreatSurvey();
                    Clientmen();
                break;
                case 2:
                    ViewSurveyByStatus();
                    Clientmen();
                break;
                case 3:
                    ViewFeedback();
                    Clientmen();
                break;
                case 4:
                    mainMenu.Menu();
                break;
                default:
                    Console.WriteLine("enter a valid number");
                break;
                
            }
        }

        public void CreatSurvey()
        {
            List<string> questions = new List<string>();
            Console.Write("enter title of your survey: ");
            string title = Console.ReadLine();
            Console.Write("How many question are under this survey: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Enter {i+1} question: ");
                string question = Console.ReadLine();
                questions.Add(question);
            }
            var surveyquestion = surveyServices.CreatSurvey(title, questions);
            surveyServices.CreatSurvey(title, questions);
            if(surveyquestion == null)
            {
                Console.WriteLine("Survey title already exist");
            }
            else
            {
                Console.WriteLine("survey succesfully created ");
            }
        }

        public void ViewSurveyByStatus()
        {
            Console.WriteLine("Enter\n1. To view approved survey\n2. To view denied survey\n3. To view pending survey");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                ViewApprovedSurvey();
            }
            else if(choice == 2)
            {
                ViewDeniedSurvey();
            }
            else if(choice == 3)
            {
                ViewPendingSurvey();
            }
            else
            {
                Console.WriteLine("Enter a valid number");
            }
        }

        public void ViewApprovedSurvey()
        {
            if(surveyServices.GetApprovedSurveyByClient(User.LoggedInUser.Email).Count == 0)
            {
                Console.WriteLine("No approved survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetApprovedSurveyByClient(User.LoggedInUser.Email);
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
        }

        public void ViewPendingSurvey()
        {
            if(surveyServices.GetPendingSurveyByClient(User.LoggedInUser.Email).Count == 0)
            {
                Console.WriteLine("No pending survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetPendingSurveyByClient(User.LoggedInUser.Email);
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
        }

        public void ViewDeniedSurvey()
        {
            if(surveyServices.GetDeniedSurveyByClient(User.LoggedInUser.Email).Count == 0)
            {
                Console.WriteLine("No denied survey at the moment");
                Clientmen();
                Console.WriteLine();
            }
            var denied = surveyServices.GetDeniedSurveyByClient(User.LoggedInUser.Email);
             int count = 1;
            foreach (var survey in denied)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }

        }

        public void ViewFeedback()
        {
            if(surveyServices.GetApprovedSurveyByClient(User.LoggedInUser.Email).Count == 0)
            {
                Console.WriteLine("no feedback at the moment check back later");
                Clientmen();
                Console.WriteLine();
            }
            var approved = surveyServices.GetApprovedSurveyByClient(User.LoggedInUser.Email).ToList();
             int count = 1;
            foreach (var survey in approved)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");   
                count++;
            }
            Console.WriteLine("Enter corresponding number of survey title you want to give feedback on");
            int choice;
            if(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > approved.Count)
            {
                Console.WriteLine("invalid input");
                Clientmen();
            }
            var surveys = approved[choice-1];
            var feedbacks = feedbackLogic.GetFeedbacks(approved[--choice].Title);
            foreach (var item in feedbacks)
            {
                Console.WriteLine($"{item.UserEmail} ");
                for (int i = 0; i < item.Answers.Count; i++)
                {
                    Console.WriteLine($"Question: {surveys.Question[i]}");
                    Console.WriteLine($"Response: {item.Answers[i]}");
                }
            }
        }

        
    }
}