using AnnuaireBloc4API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnuaireBloc4API.Dtos
{
    public partial class SiteCreateDto
    {
        [Required]
        [MaxLength(25)]
        public string City { get; set; }
    }
}