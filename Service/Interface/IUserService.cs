using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.surveyservices.Interface
{
    public interface IUserService
    {

        public User RegisterUser(string name, string lastName, string email, string password);


        public User UserLogin(string email, string password);


        public User GetUser(string email);

        void UpDateList();

        void Refresh();

    }
}