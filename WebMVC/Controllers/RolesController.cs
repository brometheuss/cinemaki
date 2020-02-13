using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RoleCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class RolesController : Controller
    {
        private readonly IGetRolesCommand getRoles;
        private readonly IGetRoleCommand getRole;
        private readonly IAddRoleCommand addRole;
        private readonly IEditRoleCommand editRole;
        private readonly IDeleteRoleCommand deleteRole;

        public RolesController(IGetRolesCommand getRoles, IGetRoleCommand getRole, IAddRoleCommand addRole, IEditRoleCommand editRole, IDeleteRoleCommand deleteRole)
        {
            this.getRoles = getRoles;
            this.getRole = getRole;
            this.addRole = addRole;
            this.editRole = editRole;
            this.deleteRole = deleteRole;
        }

        // GET: Roles
        public ActionResult Index([FromQuery] RoleQuery query)
        {
            try
            {
                return View(getRoles.Execute(query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getRole.Execute(id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/Create
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

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                addRole.Execute(dto);
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

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoleDto dto)
        {
            try
            {
                dto.Id = id;
                editRole.Execute(dto);
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

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(getRole.Execute(id));
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

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteRole.Execute(id);
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