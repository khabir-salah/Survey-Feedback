using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Interface;

namespace Survey_Feedback.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public  ICollection<User> GetAllUsers()
        {
            return SurveyContext.RegisteredUsers;
        }

        public void ReadAllFromFIle()
        {
            var RegisteredUser = File.ReadAllLines(SurveyContext.UserFile);
            foreach (var item in RegisteredUser)
            {
                var RegisteredUserLine = User.ToUser(item);
                SurveyContext.RegisteredUsers.Add(RegisteredUserLine);
            }
        }

        public void RefreshFile()
        {
            using (var str = new StreamWriter(SurveyContext.UserFile, false))
            {
                foreach (var item in SurveyContext.RegisteredUsers)
                {
                    str.WriteLine(item.ToString());
                }
            }
        }

        public User AddUser(User user)
        {
            SurveyContext.RegisteredUsers.Add(user);
            using (var str = new StreamWriter(SurveyContext.UserFile, true))
            {
                string text = user.ToString();
                str.WriteLine(text);
            }
            return user;
        }
    }
}