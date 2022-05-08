using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore6_1.Models
{
    public class AdminMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0}必填")]
        [StringLength(50)]
        [Display(Name ="名")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="{0}必填")]
        [StringLength (50)]
        [Display(Name ="姓")]
        public string? FirstName { get; set; }

        public string FullName => $"{FirstName}{LastName}";
        
        [Required(ErrorMessage = "{0}必填")]
        [EmailAddress]
        [Display(Name ="E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50)]
        [Display(Name ="帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(200)]
        [Display(Name ="密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime? CreatedAt => DateTime.Now;




    }
}
