using Annuaire_Bloc_4_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Annuaire_Bloc_4_API.Dtos
{
    public partial class EmployeeUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public string Mail { get; set; }

        [Required]
        public long DepartmentsId { get; set; }

        [Required]
        public long SitesId { get; set; }
    }
}
