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
    public class TblUserPaymentHistoriesController : Controller
    {
        private readonly JiraContext _context;

        public TblUserPaymentHistoriesController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblUserPaymentHistories
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblUserPaymentHistory.Include(t => t.FkWorkspacePayNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblUserPaymentHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserPaymentHistory = await _context.TblUserPaymentHistory
                .Include(t => t.FkWorkspacePayNavigation)
                .FirstOrDefaultAsync(m => m.PkPayId == id);
            if (tblUserPaymentHistory == null)
            {
                return NotFound();
            }

            return View(tblUserPaymentHistory);
        }

        // GET: TblUserPaymentHistories/Create
        public IActionResult Create()
        {
            ViewData["FkWorkspacePay"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed");
            return View();
        }

        // POST: TblUserPaymentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkPayId,FkWorkspacePay,PayDescription,PayAmount,PayBalance,PayDate,PayDeductions,FinalPay")] TblUserPaymentHistory tblUserPaymentHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserPaymentHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkWorkspacePay"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblUserPaymentHistory.FkWorkspacePay);
            return View(tblUserPaymentHistory);
        }

        // GET: TblUserPaymentHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserPaymentHistory = await _context.TblUserPaymentHistory.FindAsync(id);
            if (tblUserPaymentHistory == null)
            {
                return NotFound();
            }
            ViewData["FkWorkspacePay"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblUserPaymentHistory.FkWorkspacePay);
            return View(tblUserPaymentHistory);
        }

        // POST: TblUserPaymentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkPayId,FkWorkspacePay,PayDescription,PayAmount,PayBalance,PayDate,PayDeductions,FinalPay")] TblUserPaymentHistory tblUserPaymentHistory)
        {
            if (id != tblUserPaymentHistory.PkPayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserPaymentHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserPaymentHistoryExists(tblUserPaymentHistory.PkPayId))
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
            ViewData["FkWorkspacePay"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblUserPaymentHistory.FkWorkspacePay);
            return View(tblUserPaymentHistory);
        }

        // GET: TblUserPaymentHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserPaymentHistory = await _context.TblUserPaymentHistory
                .Include(t => t.FkWorkspacePayNavigation)
                .FirstOrDefaultAsync(m => m.PkPayId == id);
            if (tblUserPaymentHistory == null)
            {
                return NotFound();
            }

            return View(tblUserPaymentHistory);
        }

        // POST: TblUserPaymentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserPaymentHistory = await _context.TblUserPaymentHistory.FindAsync(id);
            _context.TblUserPaymentHistory.Remove(tblUserPaymentHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserPaymentHistoryExists(int id)
        {
            return _context.TblUserPaymentHistory.Any(e => e.PkPayId == id);
        }
    }
}
