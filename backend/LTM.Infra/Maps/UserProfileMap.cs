using LTM.Core.Infra.Maps;
using LTM.Domain.Entities;

namespace LTM.Infra.Maps
{
    public class UserProfileMap : EntityMap<UserProfile>
    {
        public UserProfileMap()
        {
            Table("UserProfile");

            Map(x => x.Name).Column("Name");
            Map(x => x.Login).Column("Login");
            Map(x => x.Password).Column("Password");

            Map(x => x.Token).Column("Token").Nullable();
            Map(x => x.ExpiresOn).Column("ExpiresOn").Nullable();
        }
    }
}
