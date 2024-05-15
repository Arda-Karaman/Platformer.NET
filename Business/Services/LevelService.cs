using Business.Models;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface ILevelService
	{
		IQueryable<LevelModel> Query();
		Result Add(LevelModel model);
		Result Update(LevelModel level);
		Result Delete(int id);
	}
	public class LevelService : ILevelService
	{
		private readonly Db _db;
		public LevelService(Db db)
		{
			_db = db;
		}
		
		public IQueryable<LevelModel> Query()
		{
			return _db.Levels.Include(p => p.Characters).Select(p => new LevelModel()
			{
				Guid = p.Guid,
				Id = p.Id,
				Name = p.Name,

				Characters = string.Join("<br/>", p.Characters.Select(m => m.Name))
			});
		}
		public Result Add(LevelModel model)
		{
			if (_db.Levels.Any(p => p.Name.ToLower() == model.Name.ToLower().Trim()))
				return new ErrorResult("Level with the same name exists!");
			Level entity = new Level()
			{
				Guid = Guid.NewGuid().ToString(),
				Name = model.Name.Trim(),
			};

			_db.Add(entity);
			_db.SaveChanges();
			return new SuccessResult();
		}

		public Result Delete(int id)
		{
			Level entity = _db.Levels.Include(r => r.Characters).SingleOrDefault(p => p.Id == id);
			if (entity is null)
				return new ErrorResult("Level is not found");
			if (entity.Characters is not null && entity.Characters.Any())
				return new ErrorResult("Level can't be deleted because it has relational characters");
			_db.Remove(entity);
			_db.SaveChanges();
			return new SuccessResult();
		}

		public Result Update(LevelModel model)
		{
			if(_db.Levels.Any(p => p.Id != model.Id && p.Name.ToLower() == model.Name.ToLower().Trim()))
				return new ErrorResult("Level with the same name exists!");
			Level entity = _db.Levels.Find(model.Id);
			if (entity is null)
				return new ErrorResult("Level is not found");
			entity.Name = model.Name.Trim();

			_db.Update(entity);
			_db.SaveChanges();
			return new SuccessResult();
		}

	}
}
