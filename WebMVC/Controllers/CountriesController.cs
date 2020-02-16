using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CountryCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly IGetCountriesCommand getCountries;
        private readonly IGetCountryCommand getCountry;
        private readonly IAddCountryCommand addCountry;
        private readonly IEditCountryCommand editCountry;
        private readonly IDeleteCountryCommand deleteCountry;

        public CountriesController(IGetCountriesCommand getCountries, IGetCountryCommand getCountry, IAddCountryCommand addCountry, IEditCountryCommand editCountry, IDeleteCountryCommand deleteCountry)
        {
            this.getCountries = getCountries;
            this.getCountry = getCountry;
            this.addCountry = addCountry;
            this.editCountry = editCountry;
            this.deleteCountry = deleteCountry;
        }

        // GET: Countries
        public ActionResult Index([FromQuery] CountryQuery query)
        {
            try
            {
                return View(getCountries.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getCountry.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Create
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

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addCountry.Execute(dto);
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

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getCountry.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CountryDto dto)
        {
            try
            {
                dto.Id = id;
                editCountry.Execute(dto);
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

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getCountry.Execute(id));
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

        // POST: Countries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteCountry.Execute(id);
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