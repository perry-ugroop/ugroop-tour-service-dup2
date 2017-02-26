using System;
using System.Collections.Generic;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        public string Nationality { get; set; }
        public bool? IsActive { get; set; }
    }
}
