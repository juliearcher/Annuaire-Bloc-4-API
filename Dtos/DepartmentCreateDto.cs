using Annuaire_Bloc_4_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Annuaire_Bloc_4_API.Dtos
{
    public partial class DepartmentCreateDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
