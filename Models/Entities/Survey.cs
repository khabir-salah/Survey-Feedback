using Survey_Feedback.Models.Enum;

public class Survey
{
    public string UserEmail { get; set; }
    public string Title { get; set; }
    public Status Status { get; set; }
    public List<string> Question { get; set; }

    public Survey(string title, List<string> question)
    {
        Title = title;
        Question = question;
        UserEmail = User.LoggedInUser.Email;
        Status = Status.pending;
    }



    public override string ToString()
    {
        string questionString = string.Join(", ", Question);
        int statusString = (int)Status;
        return $"Client Email: {UserEmail} \t Survey Title: {Title} \t Survey Status: {statusString} \t Survey Question: {questionString}";
    }

    public Survey()
    {

    }

    public static Survey ToSurveys(string str)
    {
        var survey = str.Split('\t');
        // if (survey.Length < 4)
        // {
        //     // Handle the case where the input string does not contain enough elements
        //     throw new ArgumentException("Input string does not contain enough elements.");
        // }

        string[] questionArray = survey[3].Split(": ")[1].Split(", ");
        List<string> questionList = new List<string>(questionArray);

        var surv = new Survey()
        {
            UserEmail = survey[0].Split(": ")[1],
            Title = survey[1].Split(": ")[1],
            Status = (Status)Enum.Parse(typeof(Status), survey[2].Split(": ")[1]),
            Question = questionList
        };
        return surv;
    }

    
}