using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Core.Domain
{
    public interface INHUnitOfWorkFactory
    {
        INHUnitOfWork Create();
    }
}
