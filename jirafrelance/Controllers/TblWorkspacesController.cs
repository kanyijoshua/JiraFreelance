using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using Microsoft.AspNetCore.Authorization;

namespace jirafrelance.Controllers
{
    public class TblWorkspacesController : Controller
    {
        private readonly JiraContext _context;

        public TblWorkspacesController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblWorkspaces
        [Authorize]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.bidid = id;
            var jiraContext = _context.TblWorkspace.Include(t => t.FkWkspcB).Where(x=>x.FkWkspcBid == id && x.FkWkspcB.BidStatus == "Granted");
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblWorkspaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblWorkspace = await _context.TblWorkspace
                .Include(t => t.FkWkspcB)
                .FirstOrDefaultAsync(m => m.PkWkspcId == id);
            if (tblWorkspace == null)
            {
                return NotFound();
            }

            return View(tblWorkspace);
        }

        // GET: TblWorkspaces/Create
        public IActionResult Create(int id)
        {
            ViewBag.id = id;
            ViewData["FkWkspcBid"] = new SelectList(_context.TblBid, "PkBidId", "BidOfferInformation");
            return View();
        }

        // POST: TblWorkspaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkWkspcId,FkWkspcBid,WkspcStartTime,WkspcExpectendEndTime,WkspcActualEndTime,WkspcRating,WkspcStatus,WkspcFeedback,WkspcAmountAgreed")] TblWorkspace tblWorkspace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblWorkspace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),new {tblWorkspace.FkWkspcBid});
            }
            ViewData["FkWkspcBid"] = new SelectList(_context.TblBid, "PkBidId", "BidOfferInformation", tblWorkspace.FkWkspcBid);
            return View(tblWorkspace);
        }

        // GET: TblWorkspaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblWorkspace = await _context.TblWorkspace.FindAsync(id);
            if (tblWorkspace == null)
            {
                return NotFound();
            }
            ViewData["FkWkspcBid"] = new SelectList(_context.TblBid, "PkBidId", "BidOfferInformation", tblWorkspace.FkWkspcBid);
            return View(tblWorkspace);
        }

        // POST: TblWorkspaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkWkspcId,FkWkspcBid,WkspcStartTime,WkspcExpectendEndTime,WkspcActualEndTime,WkspcRating,WkspcStatus,WkspcFeedback,WkspcAmountAgreed")] TblWorkspace tblWorkspace)
        {
            if (id != tblWorkspace.PkWkspcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblWorkspace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblWorkspaceExists(tblWorkspace.PkWkspcId))
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
            ViewData["FkWkspcBid"] = new SelectList(_context.TblBid, "PkBidId", "BidOfferInformation", tblWorkspace.FkWkspcBid);
            return View(tblWorkspace);
        }

        // GET: TblWorkspaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblWorkspace = await _context.TblWorkspace
                .Include(t => t.FkWkspcB)
                .FirstOrDefaultAsync(m => m.PkWkspcId == id);
            if (tblWorkspace == null)
            {
                return NotFound();
            }

            return View(tblWorkspace);
        }

        // POST: TblWorkspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblWorkspace = await _context.TblWorkspace.FindAsync(id);
            _context.TblWorkspace.Remove(tblWorkspace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblWorkspaceExists(int id)
        {
            return _context.TblWorkspace.Any(e => e.PkWkspcId == id);
        }

        public IActionResult Workspace()
        {
            throw new NotImplementedException();
        }
    }
}
