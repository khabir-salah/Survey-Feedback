using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback;
namespace Survey_Feedback.Repository.Interface
{
    public interface IFeedbackRepository
    {
        Feedback AddFeedback( Feedback feedback);
        ICollection<Feedback> GetFeedbacks();
        void ReadAllFromFIle();
         void RefreshFile();
        
        
    }
}