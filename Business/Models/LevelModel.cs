using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class LevelModel : Record
	{
		#region Entity Properties
		[DisplayName("Level Name")]
		[Required(ErrorMessage = "{0} is required!")]
		[StringLength(200, ErrorMessage = "{0} must be maximum {1} characters")]

		public String Name { get; set; }
		public int Score { get; set; }
		public DateTime? SaveSpot { get; set; }
		public Difficulties Difficulty { get; set; }
		#endregion
		#region Extra Properties
		public string Characters { get; set; }
		#endregion
	}
}
