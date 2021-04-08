using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.CommentCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.UserCommands;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly UseCaseExecutor executor;
        private readonly IGetCommentsCommand getComments;
        private readonly IGetCommentCommand getComment;
        private readonly IAddCommentCommand addComment;
        private readonly IEditCommentCommand editComment;
        private readonly IDeleteCommentCommand deleteComment;
        private readonly IGetUsersCommand getUsers;
        private readonly IGetMoviesCommand getMovies;

        public CommentsController(UseCaseExecutor executor, IGetCommentsCommand getComments, IGetCommentCommand getComment, IAddCommentCommand addComment, IEditCommentCommand editComment, IDeleteCommentCommand deleteComment, IGetUsersCommand getUsers, IGetMoviesCommand getMovies)
        {
            this.executor = executor;
            this.getComments = getComments;
            this.getComment = getComment;
            this.addComment = addComment;
            this.editComment = editComment;
            this.deleteComment = deleteComment;
            this.getUsers = getUsers;
            this.getMovies = getMovies;
        }

        // GET: Comments
        public ActionResult Index([FromQuery] CommentQuery query)
        {
            try
            {
                return View(executor.ExecuteQuery(getComments, query));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Home", "Index");
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getComment, id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Users = getUsers.Execute(new UserQuery { PerPage = 100000 }).Data;
                ViewBag.Movies = getMovies.Execute(new MovieQuery { PerPage = 1000 }).Data;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Create));
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, CommentDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Check your input.";
                return RedirectToAction(nameof(Create));
            }
            try
            {
                executor.ExecuteCommand(addComment, dto);
                return RedirectToAction(nameof(Details), nameof(MoviesController), new { id = dto.MovieId });
            }
            catch(EntityAlreadyHasAnEntryException e)
            {
                TempData["error"] = "You have already posted a  comment for this movie.";
                return RedirectToAction("Movies", "Home", new { id = dto.MovieId });
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction("Movies", "Home", new { id = dto.MovieId });
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getComment, id));
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }
            return RedirectToAction(nameof(Edit));
        }

        // POST: Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentDto dto)
        {
            try
            {
                dto.Id = id;
                executor.ExecuteCommand(editComment, dto);
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

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(executor.ExecuteQuery(getComment, id));
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

        // POST: Comments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                executor.ExecuteCommand(deleteComment, id);
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