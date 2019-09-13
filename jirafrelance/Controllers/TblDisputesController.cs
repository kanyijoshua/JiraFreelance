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
    public class TblDisputesController : Controller
    {
        private readonly JiraContext _context;

        public TblDisputesController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblDisputes
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblDispute.Include(t => t.FkDisptWorkspaceNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblDisputes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispute = await _context.TblDispute
                .Include(t => t.FkDisptWorkspaceNavigation)
                .FirstOrDefaultAsync(m => m.PkDisptId == id);
            if (tblDispute == null)
            {
                return NotFound();
            }

            return View(tblDispute);
        }

        // GET: TblDisputes/Create
        public IActionResult Create()
        {
            ViewData["FkDisptWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed");
            return View();
        }

        // POST: TblDisputes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkDisptId,FkDisptWorkspace,DisptReason,DisptStatus,DisptRaiseTime,DisptConclusionTime,DisptOutcome")] TblDispute tblDispute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDispute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDisptWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblDispute.FkDisptWorkspace);
            return View(tblDispute);
        }

        // GET: TblDisputes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispute = await _context.TblDispute.FindAsync(id);
            if (tblDispute == null)
            {
                return NotFound();
            }
            ViewData["FkDisptWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblDispute.FkDisptWorkspace);
            return View(tblDispute);
        }

        // POST: TblDisputes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkDisptId,FkDisptWorkspace,DisptReason,DisptStatus,DisptRaiseTime,DisptConclusionTime,DisptOutcome")] TblDispute tblDispute)
        {
            if (id != tblDispute.PkDisptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDisputeExists(tblDispute.PkDisptId))
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
            ViewData["FkDisptWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblDispute.FkDisptWorkspace);
            return View(tblDispute);
        }

        // GET: TblDisputes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispute = await _context.TblDispute
                .Include(t => t.FkDisptWorkspaceNavigation)
                .FirstOrDefaultAsync(m => m.PkDisptId == id);
            if (tblDispute == null)
            {
                return NotFound();
            }

            return View(tblDispute);
        }

        // POST: TblDisputes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDispute = await _context.TblDispute.FindAsync(id);
            _context.TblDispute.Remove(tblDispute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDisputeExists(int id)
        {
            return _context.TblDispute.Any(e => e.PkDisptId == id);
        }
    }
}
