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
    public class TblChatDirectsController : Controller
    {
        private readonly JiraContext _context;

        public TblChatDirectsController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblChatDirects
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblChatDirect.Include(t => t.FkDirectChatEmployerNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblChatDirects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatDirect = await _context.TblChatDirect
                .Include(t => t.FkDirectChatEmployerNavigation)
                .FirstOrDefaultAsync(m => m.PkDirectChatId == id);
            if (tblChatDirect == null)
            {
                return NotFound();
            }

            return View(tblChatDirect);
        }

        // GET: TblChatDirects/Create
        public IActionResult Create()
        {
            ViewData["FkDirectChatEmployer"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblChatDirects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkDirectChatId,FkDirectChatEmployer,DirectChatMessage,DirectChatTimeSent,DirectChatSender,DirectChatStatus,DirectChatTimeRead")] TblChatDirect tblChatDirect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChatDirect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkDirectChatEmployer"] = new SelectList(_context.Users, "Id", "Id", tblChatDirect.FkDirectChatEmployer);
            return View(tblChatDirect);
        }

        // GET: TblChatDirects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatDirect = await _context.TblChatDirect.FindAsync(id);
            if (tblChatDirect == null)
            {
                return NotFound();
            }
            ViewData["FkDirectChatEmployer"] = new SelectList(_context.Users, "Id", "Id", tblChatDirect.FkDirectChatEmployer);
            return View(tblChatDirect);
        }

        // POST: TblChatDirects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkDirectChatId,FkDirectChatEmployer,DirectChatMessage,DirectChatTimeSent,DirectChatSender,DirectChatStatus,DirectChatTimeRead")] TblChatDirect tblChatDirect)
        {
            if (id != tblChatDirect.PkDirectChatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChatDirect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblChatDirectExists(tblChatDirect.PkDirectChatId))
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
            ViewData["FkDirectChatEmployer"] = new SelectList(_context.Users, "Id", "Id", tblChatDirect.FkDirectChatEmployer);
            return View(tblChatDirect);
        }

        // GET: TblChatDirects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatDirect = await _context.TblChatDirect
                .Include(t => t.FkDirectChatEmployerNavigation)
                .FirstOrDefaultAsync(m => m.PkDirectChatId == id);
            if (tblChatDirect == null)
            {
                return NotFound();
            }

            return View(tblChatDirect);
        }

        // POST: TblChatDirects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblChatDirect = await _context.TblChatDirect.FindAsync(id);
            _context.TblChatDirect.Remove(tblChatDirect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblChatDirectExists(int id)
        {
            return _context.TblChatDirect.Any(e => e.PkDirectChatId == id);
        }
    }
}
