using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.Repository.Interface
{
    public interface IUserRepository
    {
         ICollection<User> GetAllUsers();
        User AddUser(User user);
        void ReadAllFromFIle();
        void RefreshFile();
    }
}