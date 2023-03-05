using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostmanScheduleRunSampleAPI.Models
{
    [Table("Users")]
    public class UsersModel
    {
        [Key]
        [Required] 
        public int UserId { get; set; }
        public string EnglishName { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;

    }
}
