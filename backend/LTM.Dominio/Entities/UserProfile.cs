using LTM.Core.Domain.Entities;
using System;

namespace LTM.Domain.Entities
{
    public class UserProfile : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual string Token { get; protected set; }
        public virtual DateTime? ExpiresOn { get; protected set; }

        protected UserProfile()
        {
        }

        public UserProfile(string name, string login, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User name is required!");

            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("User login is required!");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("User password is required!");

            this.Name = name;
            this.Login = login;
            this.Password = password;

            this.Token = string.Empty;
            this.ExpiresOn = null;
        }

        public virtual void SetToken(string token, DateTime expiresOn)
        {
            if (expiresOn > DateTime.Now && this.ExpiresOn <= DateTime.Now)
            {
                this.Token = token;
                this.ExpiresOn = expiresOn;
            }
        }        
    }
}
