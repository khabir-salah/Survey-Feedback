using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.Service.Interface
{
    public interface IAdminServices
    {
        void ApproveSurvey(string title);
        void DenySurvey(string title);
        ICollection<User> GetRegisteredUsers();
        ICollection<UnRegisteredUser> GetUnRegisteredUsers();
    }
}