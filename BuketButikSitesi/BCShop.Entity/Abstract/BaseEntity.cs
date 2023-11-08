using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCShop.Entity.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        public virtual string Name { get; set; }
    }
}
