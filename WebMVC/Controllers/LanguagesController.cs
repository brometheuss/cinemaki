using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.LanguageCommands;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Languages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Languages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Languages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Languages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}