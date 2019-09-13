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
    public class TblJobAttachmentsController : Controller
    {
        private readonly JiraContext _context;

        public TblJobAttachmentsController(JiraContext context)
        {
            _context = context;
        }

        // GET: TblJobAttachments
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblJobAttachment.Include(t => t.FkAttachmentJobNavigation);
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblJobAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJobAttachment = await _context.TblJobAttachment
                .Include(t => t.FkAttachmentJobNavigation)
                .FirstOrDefaultAsync(m => m.PkJobAttachmentId == id);
            if (tblJobAttachment == null)
            {
                return NotFound();
            }

            return View(tblJobAttachment);
        }

        // GET: TblJobAttachments/Create
        public IActionResult Create(int FkJob)
        {
            ViewBag.jobid = FkJob;
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget");
            return View();
        }

        // POST: TblJobAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkJobAttachmentId,FkAttachmentJob,JobAttachmentFilePath,JobAttachmentFileName,JobAttachmentDownloadName")] TblJobAttachment tblJobAttachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblJobAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblJobAttachment.FkAttachmentJob);
            return View(tblJobAttachment);
        }

        // GET: TblJobAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id,int jobid)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.jobid = jobid;
            var tblJobAttachment = await _context.TblJobAttachment.FindAsync(id);
            if (tblJobAttachment == null)
            {
                return NotFound();
            }
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblJobAttachment.FkAttachmentJob);
            return View(tblJobAttachment);
        }

        // POST: TblJobAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkJobAttachmentId,FkAttachmentJob,JobAttachmentFilePath,JobAttachmentFileName,JobAttachmentDownloadName")] TblJobAttachment tblJobAttachment)
        {
            if (id != tblJobAttachment.PkJobAttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblJobAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblJobAttachmentExists(tblJobAttachment.PkJobAttachmentId))
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
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblJobAttachment.FkAttachmentJob);
            return View(tblJobAttachment);
        }

        // GET: TblJobAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJobAttachment = await _context.TblJobAttachment
                .Include(t => t.FkAttachmentJobNavigation)
                .FirstOrDefaultAsync(m => m.PkJobAttachmentId == id);
            if (tblJobAttachment == null)
            {
                return NotFound();
            }

            return View(tblJobAttachment);
        }

        // POST: TblJobAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblJobAttachment = await _context.TblJobAttachment.FindAsync(id);
            _context.TblJobAttachment.Remove(tblJobAttachment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblJobAttachmentExists(int id)
        {
            return _context.TblJobAttachment.Any(e => e.PkJobAttachmentId == id);
        }
    }
}
