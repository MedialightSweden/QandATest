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
    public class AnswerTypesController : Controller
    {
        private readonly MainDbContext _context;

        public AnswerTypesController(MainDbContext context)
        {
            _context = context;    
        }

        // GET: AnswerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnswerType.ToListAsync());
        }

        // GET: AnswerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerType = await _context.AnswerType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (answerType == null)
            {
                return NotFound();
            }

            return View(answerType);
        }

        // GET: AnswerTypes/Create
        public IActionResult Create()
        {
            return PartialView("_AnswerTypeAdd"); // View();
        }

        // POST: AnswerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnswerType model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: AnswerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerType = await _context.AnswerType.SingleOrDefaultAsync(m => m.Id == id);
            if (answerType == null)
            {
                return NotFound();
            }
            return PartialView("_AnswerTypeEdit", answerType); //View(answerType);
        }

        // POST: AnswerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnswerType model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerTypeExists(model.Id))
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
            return View(model);
        }

        // GET: AnswerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerType = await _context.AnswerType.SingleOrDefaultAsync(m => m.Id == id);
            if (answerType == null)
            {
                return NotFound();
            }

            return View(answerType);
        }

        // POST: AnswerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answerType = await _context.AnswerType.SingleOrDefaultAsync(m => m.Id == id);
            _context.AnswerType.Remove(answerType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnswerTypeExists(int id)
        {
            return _context.AnswerType.Any(e => e.Id == id);
        }
    }
}
