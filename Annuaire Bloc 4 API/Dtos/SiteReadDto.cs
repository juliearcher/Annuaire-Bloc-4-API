using AnnuaireBloc4API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnnuaireBloc4API.Dtos
{
    public partial class SiteReadDto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }
    }
}
