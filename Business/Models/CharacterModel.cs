using DataAccess.Entities;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Business.Models
{
	public class CharacterModel : Record
	{
		#region Entity Properties
		[Required(ErrorMessage = "{0} is required")]
		[MinLength(2, ErrorMessage = "{0} must be minimum {1} characters!")]
		[MaxLength(100, ErrorMessage = "{0} must be maximum {1} characters!")]
		[DisplayName("Character Name")]
		public string Name { get; set; }
		[DisplayName("Character Health")]
		public double Health { get; set; }
		public int LevelId { get; set; }

		[DisplayName("Character Power")]
		public double Power { get; set; }
		[DisplayName("Character Rank")]
		public int Rank { get; set; }
		#endregion
	}
}
