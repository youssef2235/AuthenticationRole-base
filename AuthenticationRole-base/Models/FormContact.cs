using System.ComponentModel.DataAnnotations;

namespace BlueGreenEG.Models
{
    public class FormContact
    {
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Display(Name = "البريد الالكتروني")]
        public string? Email { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }
        [Display(Name = "موضوع الرسالة")]
        public string? SubMessage { get; set; }
        [Display(Name = "الرساله")]
        public string? Message { get; set; }
    }
}
