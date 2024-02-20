﻿using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class User : Record
    {
        [Required]
        [StringLength(40)]
        public string UserName { get; set; }

        [Required]
        [StringLength(40)]
        public string Password { get; set; }

        public bool isActive { get; set; }
        public Tiers Tier { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<UserCharacter> UserCharacters { get; set; }
    }
}
