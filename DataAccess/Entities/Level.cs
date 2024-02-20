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
        public float SaveSpot { get; set; }
        public Difficulties Difficulty { get; set; }
    }
}
