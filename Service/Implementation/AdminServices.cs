using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Models.Enum;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.Service.Interface;

namespace Survey_Feedback.Service.Implementation
{
    public class AdminServices : IAdminServices
    {
        ISurveyRepository surveyRepo = new SurveyRepository();
        IUnRegisteredUserRepository unRegisteredUserRepo = new UnRegistered();
        IUserRepository userRepo = new UserRepository();
        public void ApproveSurvey(string title)
        {
            var approve = surveyRepo.GetAllSurvey().FirstOrDefault(a => a.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (approve != null)
            {
                approve.Status = Status.Approved;
                surveyRepo.RefreshFile();
            }

        }

        public void DenySurvey(string title)
        {
            var deny = surveyRepo.GetAllSurvey().FirstOrDefault(a => a.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (deny != null)
            {
                deny.Status = Status.denied;
            }
        }

        public ICollection<User> GetRegisteredUsers()
        {
            return userRepo.GetAllUsers();
        }

        public ICollection<UnRegisteredUser> GetUnRegisteredUsers()
        {
            return unRegisteredUserRepo.GetUnRegisteredUsers();
        }
    }
}