using System;
using System.Collections.Generic;

#nullable disable

namespace GTN_API.Models
{
    public partial class Session
    {
        public Session()
        {
            MasteringLogs = new HashSet<MasteringLog>();
            SessionDists = new HashSet<SessionDist>();
            TranslationLogs = new HashSet<TranslationLog>();
        }

        public int sessionID { get; set; }
        public int sessionCoreID { get; set; }
        public int langID { get; set; }

        public virtual Language Lang { get; set; }
        public virtual SessionCore SessionCore { get; set; }
        public virtual ICollection<MasteringLog> MasteringLogs { get; set; }
        public virtual ICollection<SessionDist> SessionDists { get; set; }
        public virtual ICollection<TranslationLog> TranslationLogs { get; set; }
    }
}
