using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QandATest.DataAccess;
using QandATest.DomainEntities;

namespace QandATest.UI.Controllers
{
    public class QuestionTypesController : Controller
    {
        private readonly MainDbContext _context;

        public QuestionTypesController(MainDbContext context)
        {
            _context = context;    
        }

        // GET: QuestionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionType.ToListAsync());
        }

        // GET: QuestionTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionType = await _context.QuestionType.SingleOrDefaultAsync(m => m.Id == id);
        //    if (questionType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(questionType);
        //}

        // GET: QuestionTypes/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: QuestionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(questionType);
        }

        // GET: QuestionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionType = await _context.QuestionType.SingleOrDefaultAsync(m => m.Id == id);
            if (questionType == null)
            {
                return NotFound();
            }
            return PartialView("_QuestionTypeEdit", questionType); //View(questionType);
        }

        // POST: QuestionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QuestionType questionType)
        {
            if (id != questionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionTypeExists(questionType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(questionType);
        }

        // GET: QuestionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionType = await _context.QuestionType.SingleOrDefaultAsync(m => m.Id == id);
            if (questionType == null)
            {
                return NotFound();
            }

            return View(questionType);
        }

        // POST: QuestionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionType = await _context.QuestionType.SingleOrDefaultAsync(m => m.Id == id);
            _context.QuestionType.Remove(questionType);
            await _context.SaveChangesAsync();
            return Content("Delete successfully done!"); //RedirectToAction("Index");
        }

        private bool QuestionTypeExists(int id)
        {
            return _context.QuestionType.Any(e => e.Id == id);
        }
    }
}
