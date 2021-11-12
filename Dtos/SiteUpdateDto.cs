using Annuaire_Bloc_4_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Annuaire_Bloc_4_API.Dtos
{
    public partial class SiteUpdateDto
    {
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
    }
}
