using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sakugen.Models
{
    [Table("Record")]
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [Column("Token")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Token { get; set; }

        [Column("Url")]
        [MaxLength(int.MaxValue)]
        [Url]
        public string? Url { get; set; }

        [Column("DateCreate")]
        public DateTime? DateCreate { get; set; } = DateTime.UtcNow;
    }
}
