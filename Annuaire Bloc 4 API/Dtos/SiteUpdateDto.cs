using AnnuaireBloc4API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnuaireBloc4API.Dtos
{
    public partial class SiteUpdateDto
    {
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
    }
}
