using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Level : Record
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public DateTime? SaveSpot { get; set; }
        public Difficulties Difficulty { get; set; }

        //One character can play 1st level and move onto 2nd level, and then comeback to play level 1 again.
        public List<Character> Characters { get; set; }
    }
}
