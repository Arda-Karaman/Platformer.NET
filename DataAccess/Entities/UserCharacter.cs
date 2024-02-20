using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class UserCharacter : Record
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
