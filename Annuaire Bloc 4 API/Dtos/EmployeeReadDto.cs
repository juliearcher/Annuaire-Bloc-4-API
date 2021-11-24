using AnnuaireBloc4API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnuaireBloc4API.Dtos
{
    public partial class EmployeeReadDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public string Mail { get; set; }

        public string Department { get; set; }
        public string Site { get; set; }

        public long DepartmentsId { get; set; }
        public long SitesId { get; set; }
    }
}
