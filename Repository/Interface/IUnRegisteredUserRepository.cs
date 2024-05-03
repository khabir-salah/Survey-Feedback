using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey_Feedback.Repository.Interface
{
    public interface IUnRegisteredUserRepository
    {
        public ICollection<UnRegisteredUser> GetUnRegisteredUsers();
        void ReadAllFromFIle();
        void RefreshFile();

        UnRegisteredUser AddUnregisteredUser(string email);
    }
}