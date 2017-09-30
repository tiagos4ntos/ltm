using LTM.Core.Domain;

namespace LTM.Infra.Data.Core
{
    public class DefaultUnitOfWorkFactory : INHUnitOfWorkFactory
    {
        private readonly INHSession session;

        public DefaultUnitOfWorkFactory(INHSession session)
        {
            this.session = session;
        }

        public INHUnitOfWork Create()
        {
            return DefaultUnitOfWork.ReadCommitted(session);
        }
    }
}
