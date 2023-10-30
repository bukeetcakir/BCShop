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
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Açıklama")]
        [StringLength(200, ErrorMessage = "Maximum 200 karakter giriniz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Stok")]
        public int StockAmount { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Popüler")]
        public bool Popular { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }
    }
}
