#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Context;
using DataAccess.Entities;
using Business.Services;
using Business.Models;
using DataAccess.Results.Bases;
using PlatformerMVC.Controllers.Bases;
using Microsoft.AspNetCore.Authorization;

//Generated from Custom Template.
namespace PlatformerMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LevelsController : MVCControllerBase   
    {
        // TODO: Add service injections here
        private readonly ILevelService _levelService;

        public LevelsController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        // GET: Levels
        public IActionResult Index()
        {
            List<LevelModel> levelList = _levelService.Query().OrderBy(p => p.Name).ToList(); // TODO: Add get collection service logic here
            return View(levelList);
        }

        // GET: Levels/Details/5
        public IActionResult Details(int id)
        {
            LevelModel level = _levelService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (level == null)
            {
                return NotFound();
            }
            return View(level);
        }

        // GET: Levels/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Levels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LevelModel level)
        {
            if (ModelState.IsValid)
            {
                Result result = _levelService.Add(level);
                if (result.IsSuccessful)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(level);
        }

        // GET: Levels/Edit/5
        public IActionResult Edit(int id)
        {
            LevelModel level = _levelService.Query().SingleOrDefault(p =>p.Id == id); // TODO: Add get item service logic here
            if (level == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(level);
        }

        // POST: Levels/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LevelModel level)
        {
            if (ModelState.IsValid)
            {
                Result result = _levelService.Update(level);
                if(result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(level);
        }

        // GET: Levels/Delete/5
        public IActionResult Delete(int id)
        {
            LevelModel level = _levelService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (level == null)
            {
                return NotFound();
            }
            return View(level);
        }

        // POST: Levels/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _levelService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
