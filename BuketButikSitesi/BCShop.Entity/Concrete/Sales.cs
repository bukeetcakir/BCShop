using BCShop.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BCShop.Entity.Concrete
{
    public class Sales : BaseEntity
    {
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        [Display(Name = "Adet")]
        public int Quantity { get; set; }

        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Date { get; set; }

        [Display(Name = "Resim")]
        public string Image { get; set; }

        [Display(Name = "Kullanıcı")]
        public User User { get; set; }
    }
}
