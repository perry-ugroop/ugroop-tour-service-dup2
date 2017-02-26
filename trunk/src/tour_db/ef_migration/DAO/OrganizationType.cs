using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organization = new HashSet<Organization>();
        }

        public int OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
