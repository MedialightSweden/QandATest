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
    public class AnswersController : Controller
    {
        private readonly MainDbContext _context;

        public AnswersController(MainDbContext context)
        {
            _context = context;    
        }

        // GET: Answers
        public async Task<IActionResult> Index(int? id)
        {
            var answers = _context.Answer.Include(a => a.AnswerType).Include(b => b.Questionnaire).Include(c => c.Questionnaire.Question).Include(d => d.Questionnaire.Advertisement).Where(F => F.QuestionnaireId == id);
            if (answers == null || answers.Count() == 0)
            {
                ViewData["AdId"] = _context.Questionnaire.FirstOrDefault(F => F.Id == id).AdId;
                ViewData["QuestionnaireId"] = id;
                ViewData["QuestionTitle"] = _context.Questionnaire.Include(q => q.Question).FirstOrDefault(F => F.Id == id).Question.QuestionTitle;
            }
            return View(await answers.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.Include(a => a.AnswerType).SingleOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create(int? questionnaireId)
        {
            ViewData["QuestionnaireId"] = questionnaireId;
            ViewData["AnswerTypeId"] = new SelectList(_context.AnswerType, "Id", "AnswerTypeText");
            return PartialView("_AnswerAdd"); //View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Answer model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = model.QuestionnaireId });
            }
            //ViewData["AnswerTypeId"] = new SelectList(_context.AnswerType, "Id", "AnswerTypeText", model.AnswerTypeId);
            return View(model);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            ViewData["QuestionnaireId"] = answer.QuestionnaireId;
            ViewData["AnswerTypeId"] = new SelectList(_context.AnswerType, "Id", "AnswerTypeText", answer.AnswerTypeId);
            return PartialView("_AnswerEdit", answer); //View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Answer model)
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
                    if (!AnswerExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id = model.QuestionnaireId });
            }
            ViewData["AnswerTypeId"] = new SelectList(_context.AnswerType, "Id", "AnswerTypeText", model.AnswerTypeId);
            return View(model);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.Include(a => a.AnswerType).SingleOrDefaultAsync(m => m.Id == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.Id == id);
        }
    }
}
