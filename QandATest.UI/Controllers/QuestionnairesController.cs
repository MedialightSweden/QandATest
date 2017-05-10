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
    public class QuestionnairesController : Controller
    {
        private readonly MainDbContext _context;

        public QuestionnairesController(MainDbContext context)
        {
            _context = context;    
        }

        // GET: Questionnaires
        public async Task<IActionResult> Index(int? id)
        {
            var questionnaires = _context.Questionnaire.Include(q => q.Advertisement).Include(q => q.Question).Where(F => F.AdId == id);
            if (questionnaires == null || questionnaires.Count() == 0)
            {
                ViewData["AdId"] = id;
                ViewData["AdTitle"] = _context.Advertisement.FirstOrDefault(F => F.Id == id).AdTitle;
            }

            return View(await questionnaires.ToListAsync());
        }

        public IActionResult QuestionnaireGenerator(int? id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                
            }

            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = _context.Questionnaire.Include(q => q.Advertisement).Include(q => q.Question).Include(a=>a.Answers).Where(m => m.AdId == id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            ViewData["questionnaire"] = questionnaire.ToList();

            return View();
        }
        // GET: Questionnaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire.Include(q => q.Advertisement).Include(q => q.Question).SingleOrDefaultAsync(m => m.Id == id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // GET: Questionnaires/Create
        public IActionResult Create(int? adid)
        {
            ViewData["AdId"] = adid; //ViewData["AdId"] = new SelectList(_context.Advertisement, "Id", "AdTitle");
            ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "QuestionTitle");
            return PartialView("_QuestionnaireAdd"); //View();
        }

        // POST: Questionnaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Questionnaire model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = model.AdId });
            }
            //ViewData["AdId"] = new SelectList(_context.Advertisement, "Id", "AdTitle", questionnaire.AdId);
            ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "QuestionTitle", model.QuestionId);
            return View(model);
        }

        // GET: Questionnaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire.SingleOrDefaultAsync(m => m.Id == id);
            if (questionnaire == null)
            {
                return NotFound();
            }
            ViewData["AdId"] = questionnaire.AdId;
            //ViewData["AdId"] = new SelectList(_context.Advertisement, "Id", "AdTitle", questionnaire.AdId);
            ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "QuestionTitle", questionnaire.QuestionId);
            return PartialView("_QuestionnaireEdit", questionnaire); //View(questionnaire);
        }

        // POST: Questionnaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Questionnaire model)
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
                    if (!QuestionnaireExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id = model.AdId });
            }
            ViewData["AdId"] = new SelectList(_context.Advertisement, "Id", "AdTitle", model.AdId);
            ViewData["QuestionId"] = new SelectList(_context.Question, "Id", "QuestionTitle", model.QuestionId);
            return View(model);
        }

        // GET: Questionnaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionnaire = await _context.Questionnaire.Include(q => q.Advertisement).Include(q => q.Question).SingleOrDefaultAsync(m => m.Id == id);
            if (questionnaire == null)
            {
                return NotFound();
            }

            return View(questionnaire);
        }

        // POST: Questionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionnaire = await _context.Questionnaire.SingleOrDefaultAsync(m => m.Id == id);
            _context.Questionnaire.Remove(questionnaire);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QuestionnaireExists(int id)
        {
            return _context.Questionnaire.Any(e => e.Id == id);
        }
    }
}
