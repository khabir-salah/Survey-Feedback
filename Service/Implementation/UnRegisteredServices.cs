using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback.surveyservices.Implementation
{
    public class UnRegisteredServices : IUnRegisteredUserServices
    {
        IUnRegisteredUserRepository unRegisteredUserRepo = new UnRegistered();
        public UnRegisteredUser AddUnregisteredUsers(string email)
        {
            var isEmail = IfEmailExist(email);
            if (isEmail)
            {
                return null;
            }
            var unRegister = unRegisteredUserRepo.AddUnregisteredUser(email);
            return unRegister;
        }

        public void Refresh()
        {
            unRegisteredUserRepo.RefreshFile();
        }

        public void UpDateList()
        {
            unRegisteredUserRepo.ReadAllFromFIle();
        }

        private bool IfEmailExist(string email)
        {
            foreach (var user in SurveyContext.unRegisteredUsers)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}