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
		[Range(1,20,ErrorMessage = "{0} must be between 1 and 20!")]
		public double Health { get; set; }
		[DisplayName("Level")]
		[Required(ErrorMessage = "{0} is required")]
		public int? LevelId { get; set; }

		[DisplayName("Character Power")]
        [Range(1, 10, ErrorMessage = "{0} must be between 1 and 10!")]
        public double Power { get; set; }
		[DisplayName("Character Rank")]
        [Range(1, 5, ErrorMessage = "{0} must be between 1 and 5!")]
        public int Rank { get; set; }
		#endregion

		#region Extra Properties
		[DisplayName("Users")]
		public List<int>UserInput { get; set; }
		public List<UserModel> Users { get; set; }
		[DisplayName("Health")]
		public string HealthOutput { get; set; }
		[DisplayName("Level")]
		public string LevelOutput { get; set; }
		[DisplayName("Power")]
        public string PowerOutput { get; set; }
        [DisplayName("Rank")]
        public string RankOutput { get; set; }
        #endregion
    }
}
