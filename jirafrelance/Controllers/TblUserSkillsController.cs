using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;

namespace jirafrelance.Controllers
{
    public class TblUserSkillsController : Controller
    {
        private readonly JiraContext _context;

        public TblUserSkillsController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblUserSkills
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblUserSkill.Include(t => t.FkSkillUser);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblUserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill
                .Include(t => t.FkSkillUser)
                .FirstOrDefaultAsync(m => m.PkSkillId == id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }

            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Create
        public IActionResult Create()
        {
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblUserSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSkillId,FkSkillUserId,UserSkillName")] TblUserSkill tblUserSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill.FindAsync(id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // POST: TblUserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSkillId,FkSkillUserId,UserSkillName")] TblUserSkill tblUserSkill)
        {
            if (id != tblUserSkill.PkSkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserSkillExists(tblUserSkill.PkSkillId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill
                .Include(t => t.FkSkillUser)
                .FirstOrDefaultAsync(m => m.PkSkillId == id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }

            return View(tblUserSkill);
        }

        // POST: TblUserSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserSkill = await _context.TblUserSkill.FindAsync(id);
            _context.TblUserSkill.Remove(tblUserSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserSkillExists(int id)
        {
            return _context.TblUserSkill.Any(e => e.PkSkillId == id);
        }
    }
}
