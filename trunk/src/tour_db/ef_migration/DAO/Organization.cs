using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class Organization
    {
        public int OrganizationId { get; set; }
        public int? AccountId { get; set; }
        public int OrganizationTypeId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual OrganizationType OrganizationType { get; set; }
    }
}
