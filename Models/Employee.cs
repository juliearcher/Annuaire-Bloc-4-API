using System;
using System.Collections.Generic;

#nullable disable

namespace Annuaire_Bloc_4_API.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public long ServicesId { get; set; }
        public long SitesId { get; set; }

        public virtual Service Services { get; set; }
        public virtual Site Sites { get; set; }
    }
}
