using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class FavoriteModel
    {
        public int CharacterId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Character Name")]
        public string CharacterName { get; set; }
        public int? Rank { get; set; }

        [DisplayName("Rank Output")]
        public string RankOutput { get; set; }
    }
}
