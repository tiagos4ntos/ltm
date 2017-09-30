using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace LTM.WebApi.Security
{
    public class ApiIdentity : IIdentity
    {
        public string AuthenticationType
        {
            get { return "Bearer"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
        }

        private int _id;
        public int Id { get { return _id; } }

        public ApiIdentity(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}