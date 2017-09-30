using LTM.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTM.Domain.Entities
{
    public class Product : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual decimal Price { get; protected set; }

        protected Product()
        {
        }

        public Product(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Product name is required!");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("Product description is required!");

            if (price <= 0)
                throw new ArgumentNullException("Product price must be greather than zero!");

            this.Name = name;
            this.Description = description;
            this.Price = price;
        }




    }
}
