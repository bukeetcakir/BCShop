using BCShop.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Concrete
{
    public class Site : BaseEntity
    {
        public string Title { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string BrandImage { get; set; }
        public string Author { get; set; }
        public string AuthorUrl { get; set; }

    }
}
