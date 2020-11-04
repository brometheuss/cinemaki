using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.ICommands.LogCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetLogsCommand getLogs;

        public LogsController(IGetLogsCommand getLogs, UseCaseExecutor executor)
        {
            this.getLogs = getLogs;
            this.executor = executor;
        }

        // GET: Logs
        public ActionResult Index([FromQuery] LogQuery query)
        {
            try
            {
                return View(executor.ExecuteQuery(getLogs, query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Logs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
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

        // GET: Logs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logs/Edit/5
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

        // GET: Logs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logs/Delete/5
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