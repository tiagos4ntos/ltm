
namespace LTM.Core.Domain.Entities
{
    public class Entity : IEntity
    {
        public virtual int Id { get; set; }

        public virtual bool IsNew
        {
            get
            {
                return Id <= 0;
            }
        }
    }
}
