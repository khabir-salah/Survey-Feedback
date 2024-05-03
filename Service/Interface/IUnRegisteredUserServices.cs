using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.surveyservices.Interface
{
    public interface IUnRegisteredUserServices
    {
        public UnRegisteredUser AddUnregisteredUsers(string email);

        void UpDateList();

        void Refresh();
        
    }
}