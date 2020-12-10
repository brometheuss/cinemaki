﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RoleCommands;
using Application.ICommands.UserCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{

    public class UsersController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetUsersCommand getUsers;
        private readonly IGetUserCommand getUser;
        private readonly IAddUserCommand addUser;
        private readonly IEditUserCommand editUser;
        private readonly IDeleteUserCommand deleteUser;
        private readonly IGetRolesCommand getRoles;

        public UsersController(IGetUsersCommand getUsers, IGetUserCommand getUser, IAddUserCommand addUser, IGetRolesCommand getRoles, IEditUserCommand editUser, IDeleteUserCommand deleteUser, UseCaseExecutor executor)
        {
            this.getUsers = getUsers;
            this.getUser = getUser;
            this.addUser = addUser;
            this.getRoles = getRoles;
            this.editUser = editUser;
            this.deleteUser = deleteUser;
            this.executor = executor;
        }

        // GET: Users
        public ActionResult Index([FromQuery] UserQuery query)
        {
            try
            {
                return View(executor.ExecuteQuery(getUsers, query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getUser, id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Roles = getRoles.Execute(new RoleQuery()).Data;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                executor.ExecuteCommand(addUser, dto);
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Roles = getRoles.Execute(new RoleQuery()).Data;
                return View(executor.ExecuteQuery(getUser, id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShowUserDto dto)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(editUser, dto);
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getUser, id));
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

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                executor.ExecuteCommand(deleteUser, id);
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