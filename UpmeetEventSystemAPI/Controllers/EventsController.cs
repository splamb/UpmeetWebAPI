using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UpmeetEventSystemAPI.Data;
using UpmeetEventSystemAPI.Models;

namespace UpmeetEventSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : Controller
    {
        private readonly UpmeetEventSystemAPIContext _context;

        public EventsController(UpmeetEventSystemAPIContext context)
        {
            _context = context;
        }

        // GET: Events
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListEvents()
        {
            var events = await _context.Event.ToListAsync();

            var result = new OkObjectResult(events);
            return result;
        }

        // POST: Events/Create
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateEvent([Bind("EventID,Date,Location,Poster,EventName,Description")] Event @event)
        {
            var newEvent = new Event();
            newEvent.Date = @event.Date;
            newEvent.Description = @event.Description;
            newEvent.EventName = @event.EventName;
            newEvent.EventID = @event.EventID;
            newEvent.Location = @event.Location;
            newEvent.Poster = @event.Poster;

            await _context.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(newEvent);
            return result;
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,Date,Location,Poster,EventName,Description")] Event @event)
        {
            if (id != @event.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventID))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.EventID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventID == id);
        }
    }
}
