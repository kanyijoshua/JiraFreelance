using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace jirafrelance.Controllers
{
    [Authorize]
    public class TblJobsController : Controller
    {
        private readonly JiraContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TblJobsController(JiraContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TblJobs
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IQueryable<TblJob> jiraContext = _context.TblJob.Include(t => t.FkJobEmployerNavigation).Include(x=>x.TblJobAttachment).Include(x=>x.TblBid);
            if (User.IsInRole("Employer"))
            {
                jiraContext = jiraContext.Where(x => x.FkJobEmployer == _userManager.GetUserId(User));
            }
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJob
                .Include(t => t.FkJobEmployerNavigation)
                .FirstOrDefaultAsync(m => m.PkJobId == id);
            if (tblJob == null)
            {
                return NotFound();
            }

            return View(tblJob);
        }

        [Authorize(Roles = "Employer")]
        // GET: TblJobs/Create
        public IActionResult Create()
        {
            ViewData["FkJobEmployer"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> Create([Bind("PkJobId,JobTitle,JobBudget,JobCategory,JobDuration,JobDescription")] TblJob tblJob)
        {
            if (ModelState.IsValid)
            {
                tblJob.FkJobEmployer = _userManager.GetUserId(User);
                tblJob.JobStatus = "Active";
                _context.Add(tblJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkJobEmployer"] = new SelectList(_context.Users, "Id", "Id", tblJob.FkJobEmployer);
            return View(tblJob);
        }

        // GET: TblJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJob.FindAsync(id);
            if (tblJob == null)
            {
                return NotFound();
            }
            ViewData["FkJobEmployer"] = new SelectList(_context.Users, "Id", "Id", tblJob.FkJobEmployer);
            return View(tblJob);
        }

        // POST: TblJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkJobId,JobTitle,JobBudget,JobCategory,JobDuration,JobDescription,JobStatus")] TblJob tblJob)
        {
            if (id != tblJob.PkJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblJob.FkJobEmployer = _userManager.GetUserId(User);
                    _context.Update(tblJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblJobExists(tblJob.PkJobId))
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
            ViewData["FkJobEmployer"] = new SelectList(_context.Users, "Id", "Id", tblJob.FkJobEmployer);
            return View(tblJob);
        }

        // GET: TblJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblJob = await _context.TblJob
                .Include(t => t.FkJobEmployerNavigation)
                .FirstOrDefaultAsync(m => m.PkJobId == id);
            if (tblJob == null)
            {
                return NotFound();
            }

            return View(tblJob);
        }

        // POST: TblJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblJob = await _context.TblJob.FindAsync(id);
            _context.TblJob.Remove(tblJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblJobExists(int id)
        {
            return _context.TblJob.Any(e => e.PkJobId == id);
        }
    }
}
