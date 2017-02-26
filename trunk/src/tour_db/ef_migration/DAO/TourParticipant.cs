using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourParticipant
    {
        public int TourId { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsOrganizer { get; set; }
        public bool? IsParticipant { get; set; }
        public bool? IsViewer { get; set; }
        public string Status { get; set; }
        public DateTime? DateInvited { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public bool? IsConfirmed { get; set; }
        public bool? IsActive { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
