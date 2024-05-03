using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Survey_Feedback.Menu;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.surveyservices.Implementation;
using Survey_Feedback.surveyservices.Interface;


public class MainMenu
{
    ISurveyServices surveyServices = new SurveyServices();

    IUserService userService = new UserServices();
    IUnRegisteredUserServices unRegisteredUserServices = new UnRegisteredServices();
    IFeedbackServices feedbackServices = new FeedbackServices();
    public void Menu()
    {
        Console.WriteLine("===  Welcome to Survey and Feedback App  ===");
        Console.WriteLine("Enter \n1. To register \n2. To login\n3. To give feedback to a survey");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Enter a valid number");
            Menu();
        }
        switch (choice)
        {
            case 1:
                Register();
                break;
            case 2:
                Login();
                break;
            case 3:
                TakeSurvey();
                break;
        }
    }




    private void Register()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
    ReEnterEmail:
        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        string emailPattern = @"@[a-zA-Z0-9.-]+(com|COM)$";
        if (!Regex.IsMatch(email, emailPattern))
        {
            Console.WriteLine("invalid Email address\ntry again");
            goto ReEnterEmail;
        }


        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        var user = userService.RegisterUser(firstName, lastName, email, password);
        Console.WriteLine();
        if (user == null)
        {
            Console.WriteLine("Email already exist");
            Console.WriteLine();
            Menu();
        }
        else
        {
            Menu();
        }

    }



    public void Login()
    {
        Console.Write("Enter your email name: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();
        var user = userService.UserLogin(email, password);
        if (user == null)
        {
            Console.WriteLine("User doesnt exist");
            Console.WriteLine();
            Menu();
        }
        else
        {
            Console.WriteLine("Login successfull");
            Console.WriteLine();
            User.LoggedInUser = user;
            if (user.Role == "Admin")
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.AdminMen();
            }

            else if (user.Role == "Client")
            {
                ClientMenu clientMenu = new ClientMenu();
                clientMenu.Clientmen();
            }
        }

    }

    public void TakeSurvey()
    {
        if (surveyServices.ViewAllApprovedSurvey().Count == 0)
        {
            Console.WriteLine("no survey at the moment\ncheck back later");
            Menu();
            Console.WriteLine();
        }
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        unRegisteredUserServices.AddUnregisteredUsers(email);

        var approved = surveyServices.ViewAllApprovedSurvey().ToList();
        int count = 1;
        foreach (var survey in approved)
        {
            Console.WriteLine($"{count}. Survey Title: {survey.Title}");
            count++;
        }
        Console.WriteLine("Enter corresponding number of survey title you want to give feedback on");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > approved.Count)
        {
            Console.WriteLine("invalid input");
            Menu();
        }
        var surveys = approved[choice - 1];
        // bool isEmail = feedbackLogic.CheckIfFeedbackExist(surveys.Title, email);
        // if(isEmail)
        // {
        //     Console.WriteLine("You already gave feedback to this survey");
        //     Menu();
        // }
        // else 
        // {
        feedbackServices.GiveFeedback(surveys.Title, email);
        Console.WriteLine("Thank you for your response");
        Menu();
        // }


    }


}
