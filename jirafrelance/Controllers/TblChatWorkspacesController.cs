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
    public class TblChatWorkspacesController : Controller
    {
        private readonly JiraContext _context;

        public TblChatWorkspacesController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblChatWorkspaces
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblChatWorkspace.Include(t => t.FkWkspChatUserNavigation).Include(t => t.FkWkspChatWorkspaceNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblChatWorkspaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatWorkspace = await _context.TblChatWorkspace
                .Include(t => t.FkWkspChatUserNavigation)
                .Include(t => t.FkWkspChatWorkspaceNavigation)
                .FirstOrDefaultAsync(m => m.PkWkspChatId == id);
            if (tblChatWorkspace == null)
            {
                return NotFound();
            }

            return View(tblChatWorkspace);
        }

        // GET: TblChatWorkspaces/Create
        public IActionResult Create()
        {
            ViewData["FkWkspChatUser"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["FkWkspChatWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed");
            return View();
        }

        // POST: TblChatWorkspaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkWkspChatId,FkWkspChatWorkspace,FkWkspChatUser,WkspChatMessage,WkspChatTimeSent,WkspChatSender,WkspChatStatus,WkspChatTimeRead")] TblChatWorkspace tblChatWorkspace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblChatWorkspace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkWkspChatUser"] = new SelectList(_context.Users, "Id", "Id", tblChatWorkspace.FkWkspChatUser);
            ViewData["FkWkspChatWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblChatWorkspace.FkWkspChatWorkspace);
            return View(tblChatWorkspace);
        }

        // GET: TblChatWorkspaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatWorkspace = await _context.TblChatWorkspace.FindAsync(id);
            if (tblChatWorkspace == null)
            {
                return NotFound();
            }
            ViewData["FkWkspChatUser"] = new SelectList(_context.Users, "Id", "Id", tblChatWorkspace.FkWkspChatUser);
            ViewData["FkWkspChatWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblChatWorkspace.FkWkspChatWorkspace);
            return View(tblChatWorkspace);
        }

        // POST: TblChatWorkspaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkWkspChatId,FkWkspChatWorkspace,FkWkspChatUser,WkspChatMessage,WkspChatTimeSent,WkspChatSender,WkspChatStatus,WkspChatTimeRead")] TblChatWorkspace tblChatWorkspace)
        {
            if (id != tblChatWorkspace.PkWkspChatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblChatWorkspace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblChatWorkspaceExists(tblChatWorkspace.PkWkspChatId))
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
            ViewData["FkWkspChatUser"] = new SelectList(_context.Users, "Id", "Id", tblChatWorkspace.FkWkspChatUser);
            ViewData["FkWkspChatWorkspace"] = new SelectList(_context.TblWorkspace, "PkWkspcId", "WkspcAmountAgreed", tblChatWorkspace.FkWkspChatWorkspace);
            return View(tblChatWorkspace);
        }

        // GET: TblChatWorkspaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblChatWorkspace = await _context.TblChatWorkspace
                .Include(t => t.FkWkspChatUserNavigation)
                .Include(t => t.FkWkspChatWorkspaceNavigation)
                .FirstOrDefaultAsync(m => m.PkWkspChatId == id);
            if (tblChatWorkspace == null)
            {
                return NotFound();
            }

            return View(tblChatWorkspace);
        }

        // POST: TblChatWorkspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblChatWorkspace = await _context.TblChatWorkspace.FindAsync(id);
            _context.TblChatWorkspace.Remove(tblChatWorkspace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblChatWorkspaceExists(int id)
        {
            return _context.TblChatWorkspace.Any(e => e.PkWkspChatId == id);
        }
    }
}
