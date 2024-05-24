using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PlatformerMVC.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private const string _SESSIONKEY = "favoritessessionkey";

        private readonly ICharacterService _characterService;

        public FavoritesController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public IActionResult Index()
        {
            var favorites = GetSession();
            return View(favorites);
        }

        public IActionResult Add(int characterId)
        {
            var favorites = GetSession();
            var character = _characterService.GetItem(characterId);
            var favorite = new FavoriteModel()
            {
                CharacterId = character.Id,
                CharacterName = character.Name,
                Rank = character.Rank,
                RankOutput = character.RankOutput,
                UserName = User.Identity.Name
            };
            if (!favorites.Any(f => f.CharacterId == favorite.CharacterId))
                favorites.Add(favorite);
            SetSession(favorites);
            return RedirectToAction("Index", "Characters");
        }
        public IActionResult Clear()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Remove(_SESSIONKEY);
            var favorites = GetSession();
            favorites.RemoveAll(f => f.UserName == User.Identity.Name);
            SetSession(favorites);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int characterId)
        {
            var favorites = GetSession();
            favorites.RemoveAll(f => f.CharacterId == characterId);
            SetSession(favorites);
            return RedirectToAction(nameof(Index));
        }

        private List<FavoriteModel> GetSession()
        {
            var favorites = new List<FavoriteModel>();
            var json = HttpContext.Session.GetString(_SESSIONKEY);
            if (!string.IsNullOrWhiteSpace(json))
                favorites = JsonConvert.DeserializeObject<List<FavoriteModel>>(json);
            return favorites;
        }

        private void SetSession(List<FavoriteModel> favorites)
        {
            var json = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString(_SESSIONKEY, json);
        }
    }
}
