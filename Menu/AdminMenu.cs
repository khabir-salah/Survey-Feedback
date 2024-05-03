using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Survey_Feedback.Models.Enum;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.Service.Implementation;
using Survey_Feedback.Service.Interface;
using Survey_Feedback.surveyservices.Implementation;
using Survey_Feedback.surveyservices.Interface;


namespace Survey_Feedback.Menu
{
    public class AdminMenu
    {
        IUserService userLogic = new UserServices();
       ISurveyServices  surveyLogic = new SurveyServices();
        MainMenu mainMenu = new MainMenu();
        IAdminServices adminServices = new AdminServices();
        public void AdminMen()
        {
            Console.WriteLine("Enter\n1. To view all survey\n2. To approve survey\n3. To deny survey \n4. To view all registered client\n5. To view all unregistered client\n6. To exist");
            int choice = 5;
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                choice = num;
            }
            switch (choice)
            {
                case 1:
                    ViewAllSurvey();
                    break;
                case 2:
                    ApproveSurvey();
                    break;
                case 3:
                    DenySurvey();
                    break;
                case 4:
                    ViewRegisteredUsers();
                break;    
                case 5:
                    ViewUnregisteredUsers();
                break;
                case 6:
                    mainMenu.Menu();
                break;
                default:
                    Console.WriteLine("invalid input");
                    AdminMen();
                break;
            }
        }

        private void ViewAllSurvey()
        {
            
            if(surveyLogic.ViewAllApprovedSurvey().Count == 0)
            {
                Console.WriteLine("No survey yet");
                AdminMen();
                Console.WriteLine();
            }
            var allSurvey = surveyLogic.ViewAllApprovedSurvey();
            foreach (var survey in allSurvey)
            {
                var user = userLogic.GetUser(survey.UserEmail);
                Console.WriteLine($"Client name: {user.FirstName} {user.LastName}\t Client Email: {user.Email}");
                Console.WriteLine($"Survey Title:   {survey.Title}");
                Console.WriteLine("Survey Questions:");
                foreach(var question in survey.Question)
                {
                    Console.WriteLine($"{question}");
                }
            }
            AdminMen();
        }

        private void ApproveSurvey()
        {
            if(surveyLogic.GetAllPendingSurvey().Count == 0)
            {
                Console.WriteLine("No survey yet");
                AdminMen();
                Console.WriteLine();
            }
            var pendingSurvey = surveyLogic.GetAllPendingSurvey().ToList();
            int count = 1;
            foreach (var survey in pendingSurvey)
            {
                Console.WriteLine($"{count}. Survey Title: {survey.Title}");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine($"Survey Question: {question}");
                }
                count++;
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Enter the corresponding number to approve survey: ");
            int choice;
            if(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > count - 1)
            {
                Console.WriteLine("invalid input");
                AdminMen();
            }
            pendingSurvey[choice-1].Status = Status.Approved;
            Console.WriteLine("successfully approved");
            AdminMen();
        }

        public void ViewRegisteredUsers()
        {
            if(adminServices.GetRegisteredUsers().Count == 0)
            {
                Console.WriteLine("No registered User yet");
                AdminMen();
                Console.WriteLine();
            }
            var registered = adminServices.GetRegisteredUsers();
            foreach(var user in registered )
            {
                Console.WriteLine($"Client Name: {user.FirstName} {user.LastName}\tClient Email: {user.Email}");
            }
             AdminMen();
        }


        public void ViewUnregisteredUsers()
        {
            if(adminServices.GetUnRegisteredUsers().Count == 0)
            {
                Console.WriteLine("No unregistered User yet");
                AdminMen();
                Console.WriteLine();
            }
            var unregistered = adminServices.GetUnRegisteredUsers();
            foreach(var user in unregistered )
            {
                Console.WriteLine($"Client Email: {user.Email}");
            }
             AdminMen();
        }


        private void DenySurvey()
        {
            if(surveyLogic.GetAllPendingSurvey().Count == 0)
            {
                Console.WriteLine("No survey yet");
                AdminMen();
                Console.WriteLine();
            }
            var denySurvey = surveyLogic.GetAllPendingSurvey().ToList();
            int count = 1;
            foreach (var survey in denySurvey)
            {
                Console.WriteLine($"{count}. {survey.Title}");
                foreach (var question in survey.Question)
                {
                    Console.WriteLine(question);
                }
                count++;
            }
            Console.Write("Enter the corresponding number to disapprove survey: ");
            int choice;
            if(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > count - 1)
            {
                Console.WriteLine("invalid input");
                AdminMen();
            }
            denySurvey[choice-1].Status = Status.denied;
            surveyLogic.Refresh();
            Console.WriteLine("successfully approved");
            AdminMen();
        }

        

    }
}