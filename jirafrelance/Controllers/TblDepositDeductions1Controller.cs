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
    public class TblDepositDeductions1Controller : Controller
    {
        private readonly JiraContext _context;

        public TblDepositDeductions1Controller(JiraContext context)
        {
            _context = context;
        }

        // GET: TblDepositDeductions1
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblDepositDeduction.Include(t => t.FkDepositDeductionHistoryNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblDepositDeductions1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepositDeduction = await _context.TblDepositDeduction
                .Include(t => t.FkDepositDeductionHistoryNavigation)
                .FirstOrDefaultAsync(m => m.PkDepositDeductionId == id);
            if (tblDepositDeduction == null)
            {
                return NotFound();
            }

            return View(tblDepositDeduction);
        }

        // GET: TblDepositDeductions1/Create
        public IActionResult Create()
        {
            ViewData["FkDepositDeductionHistory"] = new SelectList(_context.TblEmployerDepositHistory, "PkDepositId", "DepositAmount");
            return View();
        }

        // POST: TblDepositDeductions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkDepositDeductionId,FkDepositDeductionHistory,DepositDeductionDescription,DepositDeductionAmount")] TblDepositDeduction tblDepositDeduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblDepositDeduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDepositDeductionHistory"] = new SelectList(_context.TblEmployerDepositHistory, "PkDepositId", "DepositAmount", tblDepositDeduction.FkDepositDeductionHistory);
            return View(tblDepositDeduction);
        }

        // GET: TblDepositDeductions1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepositDeduction = await _context.TblDepositDeduction.FindAsync(id);
            if (tblDepositDeduction == null)
            {
                return NotFound();
            }
            ViewData["FkDepositDeductionHistory"] = new SelectList(_context.TblEmployerDepositHistory, "PkDepositId", "DepositAmount", tblDepositDeduction.FkDepositDeductionHistory);
            return View(tblDepositDeduction);
        }

        // POST: TblDepositDeductions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkDepositDeductionId,FkDepositDeductionHistory,DepositDeductionDescription,DepositDeductionAmount")] TblDepositDeduction tblDepositDeduction)
        {
            if (id != tblDepositDeduction.PkDepositDeductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDepositDeduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDepositDeductionExists(tblDepositDeduction.PkDepositDeductionId))
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
            ViewData["FkDepositDeductionHistory"] = new SelectList(_context.TblEmployerDepositHistory, "PkDepositId", "DepositAmount", tblDepositDeduction.FkDepositDeductionHistory);
            return View(tblDepositDeduction);
        }

        // GET: TblDepositDeductions1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDepositDeduction = await _context.TblDepositDeduction
                .Include(t => t.FkDepositDeductionHistoryNavigation)
                .FirstOrDefaultAsync(m => m.PkDepositDeductionId == id);
            if (tblDepositDeduction == null)
            {
                return NotFound();
            }

            return View(tblDepositDeduction);
        }

        // POST: TblDepositDeductions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDepositDeduction = await _context.TblDepositDeduction.FindAsync(id);
            _context.TblDepositDeduction.Remove(tblDepositDeduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDepositDeductionExists(int id)
        {
            return _context.TblDepositDeduction.Any(e => e.PkDepositDeductionId == id);
        }
    }
}
