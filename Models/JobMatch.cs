using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WorkFutures.Api.Models
{
    public class JobMatch
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        [JsonIgnore] // <-- não exigir no input JSON
        public Candidate? Candidate { get; set; }

        public string JobTitle { get; set; } = string.Empty;

        public decimal MatchScore { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
