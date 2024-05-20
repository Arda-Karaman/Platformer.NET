using Business.Models;
using Business.Services.Bases;
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
#nullable disable

namespace Business.Services
{
    public interface IUserService
    {
        IQueryable<UserModel> Query();
        Result Add(UserModel model);
        Result Update(UserModel model);
        Result Delete(int id);
        List<UserModel> GetList() => Query().ToList();
        UserModel GetItem(int id) => Query().SingleOrDefault(q => q.Id == id);
    }
    public class UserService : ServiceBase, IUserService
    {
        public UserService(Db db) : base(db)
        {
        }
        public IQueryable<UserModel> Query()
        {
            return _db.Users.Include(u => u.Role).OrderByDescending(u => u.isActive).
                ThenBy(u => u.RoleId).ThenBy(u => u.UserName)
                .Select(u => new UserModel()
                {
                    Guid = u.Guid,
                    Id = u.Id,
                    isActive = u.isActive,
                    Password = u.Password,
                    RoleId = u.RoleId,
                    Tier = u.Tier,
                    UserName = u.UserName,

                    isActiveOutput = u.isActive ? "Yes" : "No",
                    RoleOutput = new RoleModel()
                    {
                        Guid = u.Guid,
                        Id = u.Id,
                        Name = u.Role.Name
                    }
                });
        }

        public Result Add(UserModel model)
        {
            if (_db.Users.Any(u => u.UserName.ToUpper() == model.UserName.ToUpper().Trim() && u.isActive))
                return new ErrorResult("Active user with the same user name exists!");
            User entity = new User()
            {
                isActive = model.isActive,
                Password = model.Password,
                RoleId = model.RoleId.Value,
                Tier = model.Tier,
                UserName = model.UserName.Trim()
            };
            
            _db.Users.Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
            return new SuccessResult("User added successfully");
        }

        public Result Delete(int id)
        {
            User entity = _db.Users.Include(u => u.UserCharacters).SingleOrDefault(u => u.Id == id);
            if (entity is null)
                return new ErrorResult("User not found!");

            _db.UserCharacters.RemoveRange(entity.UserCharacters);
            _db.Users.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("User deleted successfully");
        }

        public Result Update(UserModel model)
        {
            if (_db.Users.Any(u => u.Id != model.Id && u.UserName.ToUpper() == model.UserName.ToUpper().Trim() && u.isActive))
            {
                return new ErrorResult("Active user with the same user name exists!");
            }

            User entity = _db.Users.SingleOrDefault(u => u.Id == model.Id);
            if (entity is null)
                return new ErrorResult("User not found!");

            entity.isActive = model.isActive;
            entity.Password = model.Password.Trim();
            entity.RoleId = model.RoleId.Value;
            entity.Tier = model.Tier;
            entity.UserName = model.UserName.Trim();

            _db.Users.Update(entity);
            _db.SaveChanges();

            return new SuccessResult("User updated successfully.");
        }
    }

}
