using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Annuaire_Bloc_4_API.Models
{
    public partial class Site
    {
        public Site()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
