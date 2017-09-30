using FluentNHibernate.Mapping;
using LTM.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Core.Infra.Maps
{
    public abstract class EntityMap<T> : ClassMap<T>
        where T : Entity
    {
        protected EntityMap(string colunaId = "Id")
        {
            this.Id(x => x.Id, colunaId).GeneratedBy.Identity();           
        }
    }
}
