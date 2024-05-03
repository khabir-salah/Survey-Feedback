public class SurveyContext
{
    public static ICollection<Survey> Surveys = new List<Survey>();
    public static ICollection<Feedback> Feedbacks = new List<Feedback>();
    public static ICollection<User> RegisteredUsers = new List<User>()
    {
        new User("salah", "salah", "salah", "1234", "Admin")
    };

    public static ICollection<UnRegisteredUser> unRegisteredUsers = new List<UnRegisteredUser>();

    public static  string SurveyFile = "SurveyApp\\Surveys.txt";
    public static string FeedbackFile = "SurveyApp\\Feedbacks.txt";
    public static string UserFile = "SurveyApp\\RegisteredUsers.txt";
    public static string UnRegisteredUserFile = "SurveyApp\\unRegisteredUsers.txt";

    
}