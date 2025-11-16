using System;
using System.ComponentModel.DataAnnotations;

namespace WorkFutures.Api.Models
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // ✅ Agora o GUID é gerado no C#

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Skills { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
