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
    public class TblPaymentDeductionsController : Controller
    {
        private readonly JiraContext _context;

        public TblPaymentDeductionsController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblPaymentDeductions
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblPaymentDeduction.Include(t => t.FkPayDeductionHistoryNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblPaymentDeductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaymentDeduction = await _context.TblPaymentDeduction
                .Include(t => t.FkPayDeductionHistoryNavigation)
                .FirstOrDefaultAsync(m => m.PkPayDeductionId == id);
            if (tblPaymentDeduction == null)
            {
                return NotFound();
            }

            return View(tblPaymentDeduction);
        }

        // GET: TblPaymentDeductions/Create
        public IActionResult Create()
        {
            ViewData["FkPayDeductionHistory"] = new SelectList(_context.TblUserPaymentHistory, "PkPayId", "FinalPay");
            return View();
        }

        // POST: TblPaymentDeductions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkPayDeductionId,FkPayDeductionHistory,PayDeductionDescription,PayDeductionAmount")] TblPaymentDeduction tblPaymentDeduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPaymentDeduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPayDeductionHistory"] = new SelectList(_context.TblUserPaymentHistory, "PkPayId", "FinalPay", tblPaymentDeduction.FkPayDeductionHistory);
            return View(tblPaymentDeduction);
        }

        // GET: TblPaymentDeductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaymentDeduction = await _context.TblPaymentDeduction.FindAsync(id);
            if (tblPaymentDeduction == null)
            {
                return NotFound();
            }
            ViewData["FkPayDeductionHistory"] = new SelectList(_context.TblUserPaymentHistory, "PkPayId", "FinalPay", tblPaymentDeduction.FkPayDeductionHistory);
            return View(tblPaymentDeduction);
        }

        // POST: TblPaymentDeductions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkPayDeductionId,FkPayDeductionHistory,PayDeductionDescription,PayDeductionAmount")] TblPaymentDeduction tblPaymentDeduction)
        {
            if (id != tblPaymentDeduction.PkPayDeductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPaymentDeduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPaymentDeductionExists(tblPaymentDeduction.PkPayDeductionId))
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
            ViewData["FkPayDeductionHistory"] = new SelectList(_context.TblUserPaymentHistory, "PkPayId", "FinalPay", tblPaymentDeduction.FkPayDeductionHistory);
            return View(tblPaymentDeduction);
        }

        // GET: TblPaymentDeductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPaymentDeduction = await _context.TblPaymentDeduction
                .Include(t => t.FkPayDeductionHistoryNavigation)
                .FirstOrDefaultAsync(m => m.PkPayDeductionId == id);
            if (tblPaymentDeduction == null)
            {
                return NotFound();
            }

            return View(tblPaymentDeduction);
        }

        // POST: TblPaymentDeductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPaymentDeduction = await _context.TblPaymentDeduction.FindAsync(id);
            _context.TblPaymentDeduction.Remove(tblPaymentDeduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPaymentDeductionExists(int id)
        {
            return _context.TblPaymentDeduction.Any(e => e.PkPayDeductionId == id);
        }
    }
}
