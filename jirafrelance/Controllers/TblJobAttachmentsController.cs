using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using jirafrelance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using MimeKit;

namespace jirafrelance.Controllers
{
    public class TblJobAttachmentsController : Controller
    {
        private readonly JiraContext _context;
        private readonly IHostingEnvironment _environment;

        public TblJobAttachmentsController(JiraContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: TblJobAttachments
        public async Task<IActionResult> Index(int? FkJob)
        {
            if (FkJob == null)
            {
                return Content("Job not specified");
            }

            ViewBag.FkJob = FkJob;
            var jiraContext = _context.TblJobAttachment.Include(t => t.FkAttachmentJobNavigation).Where(x=>x.FkAttachmentJob ==FkJob);
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
        public IActionResult Create(int? FkJob)
        {
            if (FkJob ==null)
            {
                return Content("Job For the attachemnt not linked");
            }
            ViewBag.jobid = FkJob;
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget");
            return View();
        }

        // POST: TblJobAttachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Employer")]
        public async Task<IActionResult> Create([Bind("PkJobAttachmentId,FkAttachmentJob,JobAttachmentFilePath,JobAttachmentFileName,JobAttachmentDownloadName")] AttachmentViewModel tblJobAttachment)
        {
            if (ModelState.IsValid)
            {
                string uniqufilename = null;
                if (tblJobAttachment.JobAttachmentFilePath !=null && tblJobAttachment.JobAttachmentFilePath.Count>0)
                {
                    foreach (var attachment in tblJobAttachment.JobAttachmentFilePath)
                    {
                        string filefolder = Path.Combine(_environment.WebRootPath,"Files");
                        uniqufilename = Guid.NewGuid().ToString()+"_"+attachment.FileName;
                        string filepath = Path.Combine(filefolder, uniqufilename);
                        attachment.CopyTo(new FileStream(filepath, FileMode.Create));
                        TblJobAttachment jobAttachment = new TblJobAttachment()
                        {
                            FkAttachmentJob = tblJobAttachment.FkAttachmentJob,
                            JobAttachmentDownloadName = tblJobAttachment.JobAttachmentDownloadName,
                            JobAttachmentFileName = tblJobAttachment.JobAttachmentFileName,
                            JobAttachmentFilePath = uniqufilename,

                        };
                        _context.Add(jobAttachment);
                    }
                    
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"TblJobs");
            }
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblJobAttachment.FkAttachmentJob);
            return View(tblJobAttachment);
        }
        
        public IActionResult DownloadFile(string filename)
        {
            string filefolder = Path.Combine(_environment.WebRootPath,"Files");
            string filepath = Path.Combine(filefolder, filename);
            return PhysicalFile(filepath, MimeTypes.GetMimeType(filename), Path.GetFileName(filepath));
        }

        // GET: TblJobAttachments/Edit/5
        [Authorize(Roles="Employer")]
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
        [Authorize(Roles="Employer")]
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
                return RedirectToAction(nameof(Index),new{ tblJobAttachment.FkAttachmentJob });
            }
            ViewData["FkAttachmentJob"] = new SelectList(_context.TblJob, "PkJobId", "JobBudget", tblJobAttachment.FkAttachmentJob);
            return View(tblJobAttachment);
        }

        // GET: TblJobAttachments/Delete/5
        [Authorize(Roles="Employer")]
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
        [Authorize(Roles="Employer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblJobAttachment = await _context.TblJobAttachment.FindAsync(id);
            _context.TblJobAttachment.Remove(tblJobAttachment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new{ tblJobAttachment.FkAttachmentJob });
        }

        private bool TblJobAttachmentExists(int id)
        {
            return _context.TblJobAttachment.Any(e => e.PkJobAttachmentId == id);
        }
        
    }
}
