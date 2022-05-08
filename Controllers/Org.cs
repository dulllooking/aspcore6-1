using aspcore6_1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace aspcore6_1.Controllers
{
    public class Org
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50)]
        [Display(Name = "名稱")]
        public string Subject { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "建立時間")]
        public DateTime? CreatedAt => DateTime.Now;

        public ICollection<AdminMember> adminMembers { get; set; }
    }
}
