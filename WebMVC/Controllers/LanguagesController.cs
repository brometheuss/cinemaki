﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.LanguageCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly IGetLanguagesCommand getLanguages;
        private readonly IGetLanguageCommand getLanguage;
        private readonly IAddLanguageCommand addLanguage;
        private readonly IEditLanguageCommand editLanguage;
        private readonly IDeleteLanguageCommand deleteLanguage;

        public LanguagesController(IGetLanguagesCommand getLanguages, IGetLanguageCommand getLanguage, IAddLanguageCommand addLanguage, IEditLanguageCommand editLanguage, IDeleteLanguageCommand deleteLanguage)
        {
            this.getLanguages = getLanguages;
            this.getLanguage = getLanguage;
            this.addLanguage = addLanguage;
            this.editLanguage = editLanguage;
            this.deleteLanguage = deleteLanguage;
        }

        // GET: Languages
        public ActionResult Index([FromQuery] LanguageQuery query)
        {
            try
            {
                return View(getLanguages.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Languages/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getLanguage.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Languages/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Languages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addLanguage.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getLanguage.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Languages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LanguageDto dto)
        {
            try
            {
                dto.Id = id;
                editLanguage.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getLanguage.Execute(id));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Languages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteLanguage.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}