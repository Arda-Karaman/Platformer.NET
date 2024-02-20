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
    public class Character : Record
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public double Health { get; set; }
        public double Power { get; set; }
        public int Rank { get; set; }
        public List<UserCharacter> UserCharacters { get; set; }

    }
}
