﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Annuaire_Bloc_4_API.Models
{
    public partial class Employee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Surname { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public string Mail { get; set; }

        [Required]
        public long ServicesId { get; set; }

        [Required]
        public long SitesId { get; set; }

        public virtual Service Services { get; set; }
        public virtual Site Sites { get; set; }
    }
}
