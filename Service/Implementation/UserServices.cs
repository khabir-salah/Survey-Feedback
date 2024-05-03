using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Implementation;
using Survey_Feedback.Repository.Interface;
using Survey_Feedback.surveyservices.Interface;

namespace Survey_Feedback.surveyservices.Implementation
{
    public class UserServices : IUserService
    {
        IUserRepository userRepo = new UserRepository();
        public User GetUser(string email)
        {
            foreach (var user in userRepo.GetAllUsers())
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public void Refresh()
        {
            userRepo.RefreshFile();
        }

        public User RegisterUser(string name, string lastName, string email, string password)
        {
            var userEmail = IsEmailExist(email);
            if (userEmail)
            {
                return null;
            }
            var user = new User(name, lastName, email, password, "Client");
            userRepo.AddUser(user);
            return user;
        }

        public void UpDateList()
        {
            userRepo.ReadAllFromFIle();
        }

        public User UserLogin(string email, string password)
        {
            foreach (var register in userRepo.GetAllUsers())
            {
                if (register.Email == email && register.Password == password)
                {
                    return register;
                }
            }
            return null;
        }

        private bool IsEmailExist(string email)
        {
            foreach (var user in userRepo.GetAllUsers())
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