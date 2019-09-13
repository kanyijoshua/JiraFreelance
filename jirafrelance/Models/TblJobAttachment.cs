using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblJobAttachment
    {
        public int PkJobAttachmentId { get; set; }
        public int FkAttachmentJob { get; set; }
        public string JobAttachmentFilePath { get; set; }
        public string JobAttachmentFileName { get; set; }
        public string JobAttachmentDownloadName { get; set; }

        public virtual TblJob FkAttachmentJobNavigation { get; set; }
    }
}
