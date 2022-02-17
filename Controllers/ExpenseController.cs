using IdaApp.Data;
using IdaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdaApp.Controllers
{
    public class ExpenseController : Controller
    {

        private ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _db.Expenses;
            return View(expenses);
        }

        // Get - create

        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Add(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
           
        }
        
        // GET - Delete
        
        public IActionResult Delete(int? id)
        {
            
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var expense = _db.Expenses.Find(id);
            if(expense == null)
            {
                return NotFound();
            }
            
            return View(expense);
           
        }
               
        
        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var expense = _db.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
                  
        }

        //GET -Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var expense = _db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);

        }

        // POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);

        }

    }
}
