using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jirafrelance.Models;
using Microsoft.AspNetCore.Identity;

namespace jirafrelance.Controllers
{
    public class MassagesController : Controller
    {
        private readonly JiraContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public MassagesController(JiraContext context,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Massages
        public async Task<IActionResult> Index(string id)
        {
            IQueryable<Massage> jiraContext = _context.Message.Include(m => m.FkReciever).Include(m => m.FkSender);
            if (!string.IsNullOrEmpty(id))
            {
                jiraContext =
                    jiraContext.Where(x =>
                            (x.sender_id == _usermanager.GetUserId(User) && x.reciever_id == id) ||
                            (x.reciever_id == _usermanager.GetUserId(User) && x.sender_id == id))
                        .OrderBy(x => x.created_at);
            }
            else
            {
                jiraContext = jiraContext.Where(x => x.sender_id == _usermanager.GetUserId(User));
            }

            /*var sentTo = jiraContext.Where(x=>x.sender_id!=_usermanager.GetUserId(User)||x.reciever_id!=_usermanager.GetUserId(User)).Take(1).SingleOrDefault();
            var sendToId = sentTo.reciever_id ?? sentTo.reciever_id;*/
            ViewBag.sendToId = id;
            ViewBag.currentuser = _usermanager.Users.SingleOrDefault(x=>x.Id == id)?.UserName;
            return View(await jiraContext.ToListAsync());
        }

        public async Task<IActionResult> MyMasssages()
        {
            var jiraContext = _context.Message.Include(m => m.FkReciever).Include(m => m.FkSender).Where(z=>z.reciever_id==_usermanager.GetUserId(User)).OrderBy(x=>x.created_at);
            return View(await jiraContext.ToListAsync());
        }

        // GET: Massages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Message
                .Include(m => m.FkReciever)
                .Include(m => m.FkSender)
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (massage == null)
            {
                return NotFound();
            }

            return View(massage);
        }

        // GET: Massages/Create
        public IActionResult Create(string RecepietId, int? jbId, string bidstatus)
        {
            ViewBag.RecepietId = RecepietId;
            ViewBag.jbId = jbId;
            ViewBag.bidstatus = bidstatus;
            ViewData["reciever_id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["sender_id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Massages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,reciever_id,message")] Massage massage, string bidpage, int? jbId, string bidstatus)
        {
            massage.sender_id = _usermanager.GetUserId(User);
            massage.created_at = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(massage);
                await _context.SaveChangesAsync();
                if (!string.IsNullOrEmpty(bidpage))
                {
                    RedirectToAction("Bidusers","TblBids", new {jbId});
                }

                if (jbId != null)
                {
                    RedirectToAction("Index","TblBids", new {jbId, bidstatus});
                }
                return RedirectToAction(nameof(MyMasssages));
            }
            ViewData["reciever_id"] = new SelectList(_context.Users, "Id", "Id", massage.reciever_id);
            ViewData["sender_id"] = new SelectList(_context.Users, "Id", "Id", massage.sender_id);
            return View(massage);
        }
        
        public async Task<JsonResult> sendMessage([Bind("MessageId,reciever_id,message")] Massage massage)
        {
            massage.sender_id = _usermanager.GetUserId(User);
            massage.created_at = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(massage);
                await _context.SaveChangesAsync();
                var newmessage = _context.Message.SingleOrDefault(x => x.MessageId == massage.MessageId);
                
                return Json(newmessage);
            }
            
            return Json("Ok");
        }

        // GET: Massages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Message.FindAsync(id);
            if (massage == null)
            {
                return NotFound();
            }
            ViewData["reciever_id"] = new SelectList(_context.Users, "Id", "Id", massage.reciever_id);
            ViewData["sender_id"] = new SelectList(_context.Users, "Id", "Id", massage.sender_id);
            return View(massage);
        }

        // POST: Massages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MessageId,sender_id,reciever_id,message,created_at")] Massage massage)
        {
            if (id != massage.MessageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(massage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MassageExists(massage.MessageId))
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
            ViewData["reciever_id"] = new SelectList(_context.Users, "Id", "Id", massage.reciever_id);
            ViewData["sender_id"] = new SelectList(_context.Users, "Id", "Id", massage.sender_id);
            return View(massage);
        }

        // GET: Massages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var massage = await _context.Message
                .Include(m => m.FkReciever)
                .Include(m => m.FkSender)
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (massage == null)
            {
                return NotFound();
            }

            return View(massage);
        }

        // POST: Massages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var massage = await _context.Message.FindAsync(id);
            _context.Message.Remove(massage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index),new{ massage.sender_id });
        }

        private bool MassageExists(int id)
        {
            return _context.Message.Any(e => e.MessageId == id);
        }
    }
}
