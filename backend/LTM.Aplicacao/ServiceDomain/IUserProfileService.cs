using LTM.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Application.ServiceDomain
{
    public interface IUserProfileService
    {
        UserProfileDto Login(string login, string password);
        UserProfileDto GetById(int id);
    }
}
