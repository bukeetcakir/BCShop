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
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(200, ErrorMessage = "Maximum 200 karakter giriniz")]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
