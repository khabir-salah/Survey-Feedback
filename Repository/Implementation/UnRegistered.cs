using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey_Feedback.Repository.Interface;

namespace Survey_Feedback.Repository.Implementation
{
    public class UnRegistered : IUnRegisteredUserRepository
    {
        

        public void ReadAllFromFIle()
        {
            var unregister = File.ReadAllLines(SurveyContext.UnRegisteredUserFile);
            foreach (var item in unregister)
            {
                var unRegister = UnRegisteredUser.ToUnRegistered(item);
                SurveyContext.unRegisteredUsers.Add(unRegister);
            }
        }

        public void RefreshFile()
        {
            using(var str = new StreamWriter(SurveyContext.UnRegisteredUserFile, false))
            {
                foreach (var item in SurveyContext.unRegisteredUsers)
                {
                    str.WriteLine(item.ToString());
                }
                
            }
        }

        public ICollection<UnRegisteredUser> GetUnRegisteredUsers()
        {
            return SurveyContext.unRegisteredUsers;
        }

        public UnRegisteredUser AddUnregisteredUser(string email)
        {
            var unRegister = new UnRegisteredUser(email);
            SurveyContext.unRegisteredUsers.Add(unRegister);
            using(var str = new StreamWriter(SurveyContext.UnRegisteredUserFile, true))
            {
                str.WriteLine(unRegister.ToString());
            }
            return unRegister;
        }
    }
}