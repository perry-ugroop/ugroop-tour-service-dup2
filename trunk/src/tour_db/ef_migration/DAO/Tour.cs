using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class Tour
    {
        public Tour()
        {
            Newsfeed = new HashSet<Newsfeed>();
            TourParticipant = new HashSet<TourParticipant>();
            TourPlan = new HashSet<TourPlan>();
            TourReview = new HashSet<TourReview>();
        }

        public int TourId { get; set; }
        public int AccountId { get; set; }
        public int OrgId { get; set; }
        public int TourTypeId { get; set; }
        public string TourName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TourDescription { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationCoordinate { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? TargetNo { get; set; }
        public string Photo { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Newsfeed> Newsfeed { get; set; }
        public virtual ICollection<TourParticipant> TourParticipant { get; set; }
        public virtual ICollection<TourPlan> TourPlan { get; set; }
        public virtual ICollection<TourReview> TourReview { get; set; }
        public virtual TourType TourType { get; set; }
    }
}
