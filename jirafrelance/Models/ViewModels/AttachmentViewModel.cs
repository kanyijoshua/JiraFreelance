using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace jirafrelance.Models.ViewModels
{
    public class AttachmentViewModel
    {
        [Key]
        public int PkJobAttachmentId { get; set; }
        [Required]
        public int FkAttachmentJob { get; set; }
        [Required]
        public List<IFormFile> JobAttachmentFilePath { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string JobAttachmentFileName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string JobAttachmentDownloadName { get; set; }

    }
}