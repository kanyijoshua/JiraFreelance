﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using jirafrelance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

namespace jirafrelance.Controllers
{
    [Authorize(Roles = "Freelancer")]
    public class TblUserCertificationsController : Controller
    {
        private readonly JiraContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IHostingEnvironment _environment;

        public TblUserCertificationsController(JiraContext context,UserManager<ApplicationUser>userManager, IHostingEnvironment environment)
        {
            _context = context;
            _usermanager = userManager;
            _environment = environment;
        }

        // GET: TblUserCertifications
        public async Task<IActionResult> Index()
        {
            var jiraContext = _context.TblUserCertification.Include(t => t.FkCertificationUser).Where(x=>x.FkCertificationUserId ==_usermanager.GetUserId(User));
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblUserCertifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserCertification = await _context.TblUserCertification
                .Include(t => t.FkCertificationUser)
                .FirstOrDefaultAsync(m => m.PkCertificationId == id);
            if (tblUserCertification == null)
            {
                return NotFound();
            }

            return View(tblUserCertification);
        }

        // GET: TblUserCertifications/Create
        public IActionResult Create()
        {
            ViewData["FkCertificationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblUserCertifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkCertificationId,CertificationName,FkCertificationUserId")] CertificateViewModel tblUserCertification)
        {
            tblUserCertification.FkCertificationUserId = _usermanager.GetUserId(User);
                string uniqucertename = null;
                if (tblUserCertification.CertificationName != null)
                {
                    string filefolder = Path.Combine(_environment.WebRootPath,"Files");
                    uniqucertename = Guid.NewGuid().ToString()+"_"+tblUserCertification.CertificationName.FileName;
                    string filepath = Path.Combine(filefolder, uniqucertename);
                    tblUserCertification.CertificationName.CopyTo(new FileStream(filepath, FileMode.Create));
                }
                TblUserCertification newCert = new TblUserCertification()
                {
                    CertificationName = uniqucertename,
                    FkCertificationUserId = _usermanager.GetUserId(User)

                };
                _context.Add(newCert);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["FkCertificationUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserCertification.FkCertificationUserId);
            return View(tblUserCertification);
        }

        // GET: TblUserCertifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserCertification = await _context.TblUserCertification.FindAsync(id);
            if (tblUserCertification == null)
            {
                return NotFound();
            }
            ViewData["FkCertificationUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserCertification.FkCertificationUserId);
            return View(tblUserCertification);
        }

        // POST: TblUserCertifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkCertificationId,CertificationName")] TblUserCertification tblUserCertification)
        {
            if (id != tblUserCertification.PkCertificationId)
            {
                return NotFound();
            }

            tblUserCertification.FkCertificationUserId = _usermanager.GetUserId(User);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserCertification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserCertificationExists(tblUserCertification.PkCertificationId))
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
            ViewData["FkCertificationUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserCertification.FkCertificationUserId);
            return View(tblUserCertification);
        }

        // GET: TblUserCertifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserCertification = await _context.TblUserCertification
                .Include(t => t.FkCertificationUser)
                .FirstOrDefaultAsync(m => m.PkCertificationId == id);
            if (tblUserCertification == null)
            {
                return NotFound();
            }

            return View(tblUserCertification);
        }

        // POST: TblUserCertifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserCertification = await _context.TblUserCertification.FindAsync(id);
            _context.TblUserCertification.Remove(tblUserCertification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserCertificationExists(int id)
        {
            return _context.TblUserCertification.Any(e => e.PkCertificationId == id);
        }
    }
}
