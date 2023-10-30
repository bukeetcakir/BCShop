using BCShop.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;

namespace BCShop.Entity.Concrete
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "E-Posta")]
        [StringLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        [EmailAddress(ErrorMessage = "E-mail formatında giriş yapınız")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50, ErrorMessage = "Maximum 50 karakter giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Şifre")]
        [StringLength(50, ErrorMessage = "Maximum 10 karakter giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [Display(Name = "Şifre")]
        [StringLength(50, ErrorMessage = "Maximum 10 karakter giriniz")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Aynı şifreyi giriniz")]
        public string RePassword { get; set; }

        [StringLength(10,ErrorMessage ="Maximum 10 karakter olmalıdır")]
        public string Role { get; set; }

        public ICollection<Sales> Sales { get; set; }
    }
}