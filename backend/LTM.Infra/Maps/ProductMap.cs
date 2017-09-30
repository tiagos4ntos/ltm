using LTM.Core.Infra.Maps;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Infra.Maps
{
    public class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Table("Products");

            Map(x => x.Name).Column("Name");
            Map(x => x.Description).Column("Description");
            Map(x => x.Price).Column("Price");
        }
    }
}
