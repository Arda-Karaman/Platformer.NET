﻿#nullable disable
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
using PlatformerMVC.Controllers.Bases;
using DataAccess.Results;
using Microsoft.AspNetCore.Authorization;

//Generated from Custom Template.
namespace PlatformerMVC.Controllers
{
    [Authorize]
    public class CharactersController : MVCControllerBase
    {
        // TODO: Add service injections here
        private readonly ICharacterService _characterService;
        private readonly IUserService _userService;
        private readonly ILevelService _levelService;

        public CharactersController(ICharacterService characterService, IUserService userService, ILevelService levelService)
        {
            _characterService = characterService;
            _userService = userService;
            _levelService = levelService;
        }

        // GET: Characters
        public IActionResult Index()
        {
            List<CharacterModel> characterList = _characterService.GetList(); // TODO: Add get collection service logic here
            return View("List", characterList);
        }

        // GET: Characters/Details/5
        public IActionResult Details(int id)
        {
            CharacterModel character = _characterService.GetItem(id); // TODO: Add get item service logic here
            if (character == null)
            {
                return View("Error", $"Character with {id} not found");
            }
            return View(character);
        }

        // GET: Characters/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["LevelId"] = new SelectList(_levelService.Query().ToList(), "Id", "Name");
            ViewBag.Users = new MultiSelectList(_userService.GetList(), "Id", "UserName");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CharacterModel character)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _characterService.Add(character);
                if(result.IsSuccessful)
                    return RedirectToAction(nameof(Details), new { id = character.Id });
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["LevelId"] = new SelectList(_levelService.Query().ToList(), "Id", "Name");
            ViewBag.Users = new MultiSelectList(_userService.GetList(), "Id", "UserName");
            return View(character);
        }

        // GET: Characters/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            CharacterModel character = _characterService.GetItem(id); // TODO: Add get item service logic here
            if (character == null)
            {
                return View("Error", $"Character with {id} not found");
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["LevelId"] = new SelectList(_levelService.Query().ToList(), "Id", "Name");
            ViewBag.Users = new MultiSelectList(_userService.GetList(), "Id", "UserName");      
            return View(character);
        }

        // POST: Characters/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(CharacterModel character)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _characterService.Update(character);
                if (result.IsSuccessful) return RedirectToAction(nameof(Details), new { id = character.Id });
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewData["LevelId"] = new SelectList(_levelService.Query().ToList(), "Id", "Name");
            ViewBag.Users = new MultiSelectList(_userService.GetList(), "Id", "UserName");
            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var result = _characterService.Delete(id);
            TempData["Message"] =  result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
