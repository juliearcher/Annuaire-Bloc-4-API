using System;
using System.Collections.Generic;

#nullable disable

namespace Annuaire_Bloc_4_API
{
    public partial class Service
    {
        public Service()
        {
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
