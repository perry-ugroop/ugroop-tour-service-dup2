using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class TourAttachment
    {
        public int AttachmentId { get; set; }
        public int? ActivityId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public virtual TourActivities Activity { get; set; }
    }
}
