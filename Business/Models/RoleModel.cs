using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Business.Models
{
    public class RoleModel : Record
    {
        #region Entity Properties
        public string Name { get; set; }
        #endregion
    }
}
