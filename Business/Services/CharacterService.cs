using Business.Models;
using Business.Services.Bases;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Records.Bases;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
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
            //Include(g => g.Power).

			return _db.Characters.Include(g => g.Level).Include(g => g.UserCharacters).
				ThenInclude(uc => uc.User).OrderByDescending(g => g.Rank).ThenByDescending(g => g.Name).
				Select(g => new CharacterModel()
				{
					Guid = g.Guid,
					Id = g.Id,
					Rank = g.Rank,
					Name = g.Name,
					Health = g.Health,
					Power = g.Power,
					LevelId = g.LevelId,

					Users = g.UserCharacters.Select(uc => new UserModel()
					{
						UserName = uc.User.UserName,
						Tier = uc.User.Tier,

					}).ToList(),

					UserInput = g.UserCharacters.Select(uc => uc.UserId).ToList(),

					RankOutput = g.Rank.ToString(),
					HealthOutput = g.Health.ToString(),
					PowerOutput = g.Power.ToString()
				}) ;
		}
		public Result Add(CharacterModel model)
		{
			if(_db.Characters.Any(c => c.Name.ToLower()==model.Name.ToLower().Trim()))
			{
				return new ErrorResult("Character with the same name exists!");
			}
			Character entity = new Character()
			{
				Name = model.Name.Trim(),
				Guid = model.Guid,
				Id = model.Id,
				Rank = model.Rank,
				Health = model.Health,
				Power = model.Power,
				LevelId = model.LevelId,
				
				UserCharacters = model.UserInput?.Select(userInput => new UserCharacter()
				{
					UserId = userInput
				}).ToList(),
			};

			_db.Characters.Add(entity);
			_db.SaveChanges();

			model.Id = entity.Id;
			return new SuccessResult();
		}

		public Result Delete(int id)
		{
            Character entity = _db.Characters.Include(c => c.UserCharacters).SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return new ErrorResult("Character not found!");

            _db.UserCharacters.RemoveRange(entity.UserCharacters);

            _db.Characters.Remove(entity);
            _db.SaveChanges();

            return new SuccessResult("Character deleted successfully.");
        }

		public IQueryable<CharacterModel> Query()
		{
			throw new NotImplementedException();
		}

		public Result Update(CharacterModel model)
		{
			if (_db.Characters.Any(c => c.Id != model.Id && c.Name.ToLower() == model.Name.ToLower().Trim()))
				return new ErrorResult("Character with same name exists");

			Character entity = _db.Characters.Include(c => c.UserCharacters).SingleOrDefault(c => c.Id == model.Id);
			if (entity == null) return new ErrorResult("Character not found");
			_db.UserCharacters.RemoveRange(entity.UserCharacters);

			entity.Name = model.Name.Trim();
			entity.Guid = model.Guid;
			entity.Id = model.Id;
			entity.Rank = model.Rank;
			entity.Health = model.Health;
			entity.Power = model.Power;
			entity.LevelId = model.LevelId;

			entity.UserCharacters = model.UserInput?.Select(userInput => new UserCharacter()
			{
				UserId = userInput
			}).ToList();

			_db.Characters.Update(entity);
			_db.SaveChanges();

			return new SuccessResult();
		}
	}
}
