using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(50)]
        public byte[] Password { get; set; }

        [Required]
        [StringLength(32)]
        public string PasswordSalt { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [Required]
        [StringLength(32)]
        public string UserKey { get; set; }

        [Required]
        [StringLength(32)]
        public string ResetKey { get; set; }

        public DateTime? ResetKeyTime { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}