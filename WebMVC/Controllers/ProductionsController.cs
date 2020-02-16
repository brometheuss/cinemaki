using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.ProductionCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ProductionsController : Controller
    {
        private readonly IGetProductionsCommand getProductions;
        private readonly IGetProductionCommand getProduction;
        private readonly IAddProductionCommand addProduction;
        private readonly IEditProductionCommand editProduction;
        private readonly IDeleteProductionCommand deleteProduction;

        public ProductionsController(IGetProductionsCommand getProductions, IGetProductionCommand getProduction, IAddProductionCommand addProduction, IEditProductionCommand editProduction, IDeleteProductionCommand deleteProduction)
        {
            this.getProductions = getProductions;
            this.getProduction = getProduction;
            this.addProduction = addProduction;
            this.editProduction = editProduction;
            this.deleteProduction = deleteProduction;
        }

        // GET: Productions
        public ActionResult Index([FromQuery] ProductionQuery query)
        {
            try
            {
                return View(getProductions.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Productions/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getProduction.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Productions/Create
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

        // POST: Productions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductionDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addProduction.Execute(dto);
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

        // GET: Productions/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(getProduction.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Productions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductionDto dto)
        {
            try
            {
                dto.Id = id;
                editProduction.Execute(dto);
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

        // GET: Productions/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getProduction.Execute(id));
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

        // POST: Productions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteProduction.Execute(id);
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