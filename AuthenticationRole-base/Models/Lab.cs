using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationRole_base.Models
{
    public class Lab
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "العميل")]
        [Required(ErrorMessage = "يرجى إدخال اسم العميل")]
        public string ClientName { get; set; }

        [Display(Name = "الموقع")]
        public string Location { get; set; }

        [Display(Name = "نوع العينة")]
        public string SampleType { get; set; }

        [Display(Name = "تاريخ الاستلام")]
        [DataType(DataType.Date)]
        public DateTime ReceivedDate { get; set; }

        [Display(Name = "تاريخ التقرير")]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        // Chemical Properties
        [Display(Name = "درجة الحموضة (pH)")]
        [Range(0, 14)]
        public double? pH { get; set; }

        [Display(Name = "الموصلية الكهربائية (EC)")]
        public double? ElectricalConductivity { get; set; }

        [Display(Name = "المادة العضوية")]
        public double? OrganicMatter { get; set; }

        [Display(Name = "النيتروجين الكلي")]
        public double? TotalNitrogen { get; set; }

        [Display(Name = "الفوسفور المتاح")]
        public double? AvailablePhosphorus { get; set; }

        [Display(Name = "البوتاسيوم المتبادل")]
        public double? ExchangePotassium { get; set; }

        [Display(Name = "الكالسيوم")]
        public double? Calcium { get; set; }

        [Display(Name = "المغنيسيوم")]
        public double? Magnesium { get; set; }

        [Display(Name = "الحديد")]
        public double? Iron { get; set; }

        [Display(Name = "الزنك")]
        public double? Zinc { get; set; }

        // Physical Properties
        [Display(Name = "نسبة الرمل")]
        public double? SandPercentage { get; set; }

        [Display(Name = "نسبة الطين")]
        public double? ClayPercentage { get; set; }

        [Display(Name = "نسبة الغرين")]
        public double? SiltPercentage { get; set; }

        [Display(Name = "الكثافة الظاهرية")]
        public double? ApparentDensity { get; set; }

        public string? Problems { get; set; }
        public string? Recommendations { get; set; }
    }
}