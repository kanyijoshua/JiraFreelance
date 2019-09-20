using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace jirafrelance.Controllers
{
    public class TblBidsController : Controller
    {
        private readonly JiraContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TblBidsController(JiraContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //[Route(Name ="dd")]
        // GET: TblBids
        public async Task<IActionResult> Index(int? JobBidded, string bidstatus)
        {
            IQueryable<TblBid> jiraContextdb = _context.TblBid.Include(t => t.FkBidUserNavigation).Include(t => t.FkJobBiddedNavigation);
            if (User.IsInRole("Employer"))
            {
                jiraContextdb = jiraContextdb.Where(z => z.FkJobBidded == JobBidded);
            }
            if (User.IsInRole("Freelancer"))
            {
                var bidfilter = bidstatus ?? "Active";
                ViewBag.bidfilter = bidfilter;
                jiraContextdb = jiraContextdb.Where(z => z.FkBidUserNavigation.Id == _userManager.GetUserId(User)).Where(x=>x.BidStatus==bidfilter);
            }
            return View(await jiraContextdb.ToListAsync());
        }

        public async Task<IActionResult> Workspace(int? JobBidded)
        {
            IQueryable<TblBid> jiraContextdb = _context.TblBid.Include(t => t.FkBidUserNavigation).Include(t => t.FkJobBiddedNavigation);
            if (User.IsInRole("Employer"))
            {
                jiraContextdb = jiraContextdb.Where(z => z.FkJobBidded == JobBidded);
            }
            if (User.IsInRole("Freelancer"))
            {
                jiraContextdb = jiraContextdb.Where(z => z.FkBidUserNavigation.Id == _userManager.GetUserId(User)).Where(x => x.BidStatus == "Granted");
            }
            return View(await jiraContextdb.ToListAsync());
        }

        public async Task<IActionResult> Bidusers(int? jobId)
        {
            IQueryable<TblBid> jiraContext = _context.TblBid.Include(z=>z.FkJobBiddedNavigation).Include(x=>x.FkJobBiddedNavigation.FkJobEmployerNavigation).Include(x=>x.FkBidUserNavigation);
            if (User.IsInRole("Support"))
            {
                jiraContext = jiraContext;
            }

            if (User.IsInRole("Employer"))
            {
                jiraContext = jiraContext.Where(x => x.FkJobBidded == jobId);
            }
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblBids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBid = await _context.TblBid
                .Include(t => t.FkBidUserNavigation)
                .Include(t => t.FkJobBiddedNavigation)
                .FirstOrDefaultAsync(m => m.PkBidId == id);
            if (tblBid == null)
            {
                return NotFound();
            }

            return View(tblBid);
        }

        // GET: TblBids/Create
        public IActionResult Create(string JobId)
        {
            ViewBag.tojob = "tojobtable";
            ViewBag.JobId = JobId;
            ViewData["FkBidUser"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["FkJobBidded"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget");
            return View();
        }

        // POST: TblBids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> Create([Bind("PkBidId,FkJobBidded,BidOfferInformation")]TblBid tblBid, string tojob)
        {
            //if (ModelState.IsValid)
            //{
                tblBid.BidTime = DateTime.Now.ToString();
                tblBid.FkBidUser = _userManager.GetUserId(User);
                tblBid.BidStatus = "Active";
                tblBid.BidAwardTime = "";
                _context.Add(tblBid);
                await _context.SaveChangesAsync();
                if (tojob.Length > 0)
                {
                    return RedirectToAction("Index", "TblJobs");
                }
                return RedirectToAction(nameof(Index));
            //}

            // ViewData["FkBidUser"] = new SelectList(_context.Users, "Id", "Id", tblBid.FkBidUser);
            // ViewData["FkJobBidded"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblBid.FkJobBidded);
            //if (tojob.Length > 0)
            //{
            //    return RedirectToAction("Index", "TblJobs");
            //}

            // return View(tblBid);
        }

        // GET: TblBids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBid = await _context.TblBid.FindAsync(id);
            ViewBag.JobId = tblBid.FkJobBidded;
            ViewBag.BidTime = tblBid.BidTime;
            ViewBag.BidAwardTime = tblBid.BidAwardTime;
            ViewBag.FkBidUser = tblBid.FkBidUser;
            ViewBag.BidStatus = tblBid.BidStatus;
            if (tblBid == null)
            {
                return NotFound();
            }

            ViewData["FkBidUser"] = new SelectList(_context.Users, "Id", "Id", tblBid.FkBidUser);
            ViewData["FkJobBidded"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblBid.FkJobBidded);
            return View(tblBid);
        }

        // POST: TblBids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, int PkBidId)
            //[Bind("PkBidId,BidStatus")]
            //TblBid tblBid)
        {
            //if (id != tblBid.PkBidId)
            //{
            //    return NotFound();
            //}
            var bidupdate = _context.TblBid.SingleOrDefault(x => x.PkBidId == PkBidId);
            if (ModelState.IsValid)
            {
                try
                {
                    bidupdate.BidStatus = "Granted";
                    bidupdate.BidAwardTime = DateTime.Now.ToString();
                    var job_edit = _context.TblJob.SingleOrDefault(x => x.PkJobId== bidupdate.FkJobBidded);
                    _context.Update(bidupdate);
                    job_edit.JobStatus = "Granted";
                    _context.Update(job_edit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBidExists(bidupdate.PkBidId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index), new { JobBidded = bidupdate.FkJobBidded });
            }

            ViewData["FkBidUser"] = new SelectList(_context.Users, "Id", "Id", bidupdate.FkBidUser);
            ViewData["FkJobBidded"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", bidupdate.FkJobBidded);
            return View(bidupdate);
        }
        public async Task<IActionResult> Grantbid(int PkBidId, string grantstate)
        {
            var bidupdate = _context.TblBid.SingleOrDefault(x => x.PkBidId == PkBidId);
            var job_edit = _context.TblJob.SingleOrDefault(x => x.PkJobId== bidupdate.FkJobBidded);
            var tblWorkspace = _context.TblWorkspace.Where(x => x.FkWkspcBid == PkBidId);
            try
            {
                if (grantstate=="grant")
                {
                    bidupdate.BidStatus = "Granted";
                    bidupdate.BidAwardTime = DateTime.Now.ToString();
                    job_edit.JobStatus = "Granted";
                }

                if (grantstate=="ungrant")
                {
                    foreach (var bids in _context.TblBid.Where(x=>x.FkJobBidded== bidupdate.FkJobBidded))
                    {
                        bids.BidStatus = "Active";
                    }
                    bidupdate.BidAwardTime = "";
                    job_edit.JobStatus = "Active";
                    if (tblWorkspace.Any())
                    {
                        foreach (var wks in tblWorkspace)
                        {
                            _context.TblWorkspace.Remove(wks);
                        }
                    }
                    
                }
                
                _context.Update(bidupdate);
                _context.Update(job_edit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBidExists(bidupdate.PkBidId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Bidusers), new { jobId = bidupdate.FkJobBidded });

        }

        // GET: TblBids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBid = await _context.TblBid
                .Include(t => t.FkBidUserNavigation)
                .Include(t => t.FkJobBiddedNavigation)
                .FirstOrDefaultAsync(m => m.PkBidId == id);
            if (tblBid == null)
            {
                return NotFound();
            }

            return View(tblBid);
        }

        // POST: TblBids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBid = await _context.TblBid.FindAsync(id);
            _context.TblBid.Remove(tblBid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBidExists(int id)
        {
            return _context.TblBid.Any(e => e.PkBidId == id);
        }
    }
}