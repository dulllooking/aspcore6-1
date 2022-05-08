using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore6_1.Models
{
    public class Contact_Us
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50)]
        [Display(Name = "標題")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "{0}必填")]
        [StringLength(500)]
        [Display(Name = "內容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime? CreatedAt => DateTime.Now;
    }
}
