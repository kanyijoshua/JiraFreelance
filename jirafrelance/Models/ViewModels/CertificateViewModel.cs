using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace jirafrelance.Models.ViewModels
{
    public class CertificateViewModel
    {
        [Key]
        public int PkCertificationId { get; set; }
        [Required]
        public string FkCertificationUserId { get; set; }
        [Required]
        public IFormFile CertificationName { get; set; }
    }
}