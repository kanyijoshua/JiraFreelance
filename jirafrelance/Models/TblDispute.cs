using System;
using System.Collections.Generic;

namespace jirafrelance.Models
{
    public partial class TblDispute
    {
        public int PkDisptId { get; set; }
        public int FkDisptWorkspace { get; set; }
        public string DisptReason { get; set; }
        public string DisptStatus { get; set; }
        public string DisptRaiseTime { get; set; }
        public string DisptConclusionTime { get; set; }
        public string DisptOutcome { get; set; }

        public virtual TblWorkspace FkDisptWorkspaceNavigation { get; set; }
    }
}
