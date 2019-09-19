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
using Microsoft.EntityFrameworkCore.Internal;

namespace jirafrelance.Controllers
{
    public class TblUserSkillsController : Controller
    {
        private readonly JiraContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public TblUserSkillsController(JiraContext context,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _usermanager = userManager;
        }
        [Authorize(Roles = "Admin,Freelancer,Employer")]
        // GET: TblUserSkills
        public async Task<IActionResult> Index(string id)
        {
            IQueryable<TblUserSkill> jiraContext = _context.TblUserSkill.Include(t => t.FkSkillUser);
            var skillcert = from tblUserSkill in _context.TblUserSkill
                join certs in _context.TblUserCertification on tblUserSkill.FkSkillUserId equals certs
                    .FkCertificationUserId select new {tblUserSkill , certs};
            
            var certskill = _context.TblUserSkill.Join(
                _context.TblUserCertification,
                skill => skill.FkSkillUserId,
                cert => cert.FkCertificationUserId,
                (skill, cert) =>
                new {skill, cert});
            if (!string.IsNullOrEmpty(id))
            {
                jiraContext = jiraContext.Where(x => x.FkSkillUser.Id == id)
                .Select(z => new TblUserSkill { UserSkillName = z.UserSkillName, FkSkillUserId = z.FkSkillUser.UserName });
            }
            if (User.IsInRole("Freelancer"))
            {
                jiraContext = jiraContext.Where(x => x.FkSkillUserId == _usermanager.GetUserId(User))
                .Select(z => new TblUserSkill { UserSkillName = z.UserSkillName, FkSkillUserId = z.FkSkillUser.UserName,PkSkillId = z.PkSkillId});
            }
            return View(await jiraContext.ToListAsync());
        }

        // GET: TblUserSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill
                .Include(t => t.FkSkillUser)
                .FirstOrDefaultAsync(m => m.PkSkillId == id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }

            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Create
        public IActionResult Create()
        {
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblUserSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Freelancer")]
        public async Task<IActionResult> Create([Bind("PkSkillId,UserSkillName")] TblUserSkill tblUserSkill)
        {
            tblUserSkill.FkSkillUserId = _usermanager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(tblUserSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Edit/
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill.FindAsync(id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // POST: TblUserSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> Edit(int id, [Bind("PkSkillId,UserSkillName")] TblUserSkill tblUserSkill)
        {
            if (id != tblUserSkill.PkSkillId)
            {
                return NotFound();
            }

            tblUserSkill.FkSkillUserId = _usermanager.GetUserId(User);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUserSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserSkillExists(tblUserSkill.PkSkillId))
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
            ViewData["FkSkillUserId"] = new SelectList(_context.Users, "Id", "Id", tblUserSkill.FkSkillUserId);
            return View(tblUserSkill);
        }

        // GET: TblUserSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUserSkill = await _context.TblUserSkill
                .Include(t => t.FkSkillUser)
                .FirstOrDefaultAsync(m => m.PkSkillId == id);
            if (tblUserSkill == null)
            {
                return NotFound();
            }

            return View(tblUserSkill);
        }

        // POST: TblUserSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUserSkill = await _context.TblUserSkill.FindAsync(id);
            _context.TblUserSkill.Remove(tblUserSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserSkillExists(int id)
        {
            return _context.TblUserSkill.Any(e => e.PkSkillId == id);
        }
    }
}
