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

//Generated from Custom Template.
namespace PlatformerMVC.Controllers
{
    public class CharactersController : Controller
    {
        // TODO: Add service injections here
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
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
            CharacterModel character = null; // TODO: Add get item service logic here
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterModel character)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(character);
        }

        // GET: Characters/Edit/5
        public IActionResult Edit(int id)
        {
            CharacterModel character = null; // TODO: Add get item service logic here
            if (character == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(character);
        }

        // POST: Characters/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CharacterModel character)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(character);
        }

        // GET: Characters/Delete/5
        public IActionResult Delete(int id)
        {
            CharacterModel character = null; // TODO: Add get item service logic here
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}