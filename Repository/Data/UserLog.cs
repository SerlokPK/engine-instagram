using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Data
{
    public class UserLog
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogId { get; set; }

        [Required]
        [StringLength(32)]
        public string LogKey { get; set; }

        public DateTime LogTime { get; set; }

        public virtual User User { get; set; }
    }
}
