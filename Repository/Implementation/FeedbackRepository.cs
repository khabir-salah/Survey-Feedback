
using Survey_Feedback.Repository.Interface;

namespace Survey_Feedback.Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    { 
        public Feedback AddFeedback(Feedback feedback)
        {
            SurveyContext.Feedbacks.Add(feedback);
            using(var str = new StreamWriter(SurveyContext.FeedbackFile, true))
            {
                str.WriteLine(feedback.ToString());
            }
            return feedback;

        }

        public ICollection<Feedback> GetFeedbacks()
        {
           return SurveyContext.Feedbacks;
        }

        public void ReadAllFromFIle()
        {
            var feedback = File.ReadAllLines(SurveyContext.FeedbackFile);
            foreach(var item in feedback)
            {
                var feedbackLine = Feedback.ToFeedbacks(item);
                SurveyContext.Feedbacks.Add(feedbackLine);
            }
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(SurveyContext.FeedbackFile, false))
            {
                foreach (var item in SurveyContext.Feedbacks)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }
    }
}