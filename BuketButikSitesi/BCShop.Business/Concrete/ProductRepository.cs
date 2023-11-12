using BCShop.Business.Abstract;
using BCShop.Data.Contexts;
using BCShop.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Business.Concrete
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(Context dbcontext) : base(dbcontext)
        {
        }

    }
}
