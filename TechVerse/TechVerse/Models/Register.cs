using System.ComponentModel.DataAnnotations;
using TechVerse.Utilities;

namespace TechVerse.Models
{
    public class Register
    {
        [Display(Name = "الاسم الكامل")]
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string? FullName { get; set; }

        [Display(Name = "البريد الإلكتروني")]
        [Required(ErrorMessage = "البريد مطلوب")]
        [EmailAddress(ErrorMessage = "إيميل غير صحيح")]
        public string? Email { get; set; }

        [Display(Name = "كلمة المرور")]
        [Required(ErrorMessage = "الباسوورد مطلوب")]
        [MinLength(6, ErrorMessage = "على الأقل 6 حروف")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password", ErrorMessage = "غير متطابق")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "العمر")]
        [Range(12, 100, ErrorMessage = "فوق 12 سنة")]
        public int Age { get; set; }

        [Display(Name = "الدولة")]
        [Required]
        public string? Country { get; set; }

        [Phone(ErrorMessage = "رقم الهاتف غير صحيح")]
        public string? PhoneNumber { get; set; }

        // [MustBeTrue(ErrorMessage = "يجب الموافقة على الشروط")]
        public bool AgreeToTerms { get; set; }
    }
}
