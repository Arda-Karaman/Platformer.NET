using Business.Models;
using Business.Services.Bases;
using DataAccess.Context;
using DataAccess.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Business.Services
{
	public interface ICharacterService
	{
		IQueryable<CharacterModel> Query();
		Result Add(CharacterModel model);
		Result Delete(int id);
		Result Update(CharacterModel model);
		List<CharacterModel> GetList() => Query().ToList();
		CharacterModel GetItem(int id) => Query().SingleOrDefault(g => g.Id == id);
	}

	public class CharacterService : ServiceBase, ICharacterService
	{
		public CharacterService(Db db) : base(db)
		{
		}

		IQueryable<CharacterModel> ICharacterService.Query() 
		{
			return _db.Characters.OrderByDescending(g => g.Rank).ThenByDescending(g => g.Name).
				Select(g => new CharacterModel()
				{
					Guid = g.Guid,
					Id = g.Id,
					Rank = g.Rank,
					Name = g.Name
				});
		}
		public Result Add(CharacterModel model)
		{
			throw new NotImplementedException();
		}

		public Result Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<CharacterModel> Query()
		{
			throw new NotImplementedException();
		}

		public Result Update(CharacterModel model)
		{
			throw new NotImplementedException();
		}
	}
}
