using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadiaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcadiaProject.Controllers
{
    public class MessagesController : Controller
    {
        private readonly CrudExampleContext _context;
        public MessagesController(CrudExampleContext context)
        {
            _context = context;
        }

        public ActionResult ListMessages()
        {
            var result = _context.Messages.ToList();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = _context.Messages.Where(m => m.Id == id).FirstOrDefault();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection data)
        {
            try
            {
                var message = new Messages
                {
                    Date = DateTime.Now,
                    Message = data["Message"]
                };

                _context.Messages.Add(message);
                _context.SaveChanges();

                return RedirectToAction(nameof(ListMessages));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            var message = _context.Messages.Where(m => m.Id == id).Single();
            _context.Messages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction(nameof(ListMessages));
        }
        public ActionResult Edit(int id)
        {
            var result = _context.Messages.Where(m => m.Id == id).Single();
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, IFormCollection data)
        {
            try
            {
                var message = _context.Messages.Where(m => m.Id == id).Single();

                message.Message = data["Message"];
                message.Date = DateTime.Now;

                _context.Messages.Update(message);
                _context.SaveChanges();

                return RedirectToAction(nameof(ListMessages));
            }
            catch
            {
                return View();
            }
        }
    }
}