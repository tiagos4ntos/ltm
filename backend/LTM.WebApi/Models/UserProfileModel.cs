using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTM.WebApi.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}