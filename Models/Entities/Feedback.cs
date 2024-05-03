public class Feedback
{
    public string UserEmail {get; set;}
    public string SurveyTitle {get; set;}
    public List<string> Answers {get; set;}

    public Feedback(string userEmail, string surveyTitle, List<string> answer)
    {
        UserEmail = userEmail;
        SurveyTitle = surveyTitle;
        Answers = answer;
    }

    public Feedback()
    {
    }

    public override string ToString()
    {
        string answersString = string.Join(",", Answers);
        return $"Client Email: {UserEmail}\tSurvey Title: {SurveyTitle}\tSurvey Response: {answersString}";
    }

    public static Feedback ToFeedbacks(string str)
    {
        var feedback = str.Split('\t');
        
        string[] feedbackArray = feedback[2].Split(": ")[1].Split(',');
        List<string> feedbackList = new List<string>(feedbackArray);
       

        return new Feedback()
        {
            UserEmail = feedback[0].Split(": ")[1],
            SurveyTitle = feedback[1].Split(": ")[1],
            Answers = feedbackList
        };
    }
}