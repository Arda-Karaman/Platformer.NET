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
    public class Block : Record
    {
        public Types Type { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

    }
}
