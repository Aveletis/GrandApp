using GrandApp.Models;
using GrandApp.Models.Data;
using GrandApp.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace GrandApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppCtx _context;

        public ReservationsController(AppCtx context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index(CreateReservationsViewModel model)
        {
            var appCtx = _context.Reservations
               .OrderBy(f => f.ArrivaldateTime);
            return View(await appCtx.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var Reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Reservations == null)
            {
                return NotFound();
            }

            return View(Reservations);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "Number");
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname");
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationsViewModel model)
        {
            /*
           
            }*/

            if (_context.Reservations
                .Where(f => model.ArrivaldateTime >= model.DeparturedateTime)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Дата заезда должна быть до даты выезда");
            }
            else if(_context.Reservations
                .Where(f => (f.IdRoom == model.IdRoom) && (((model.ArrivaldateTime >= f.ArrivaldateTime) && (model.ArrivaldateTime <= f.DeparturedateTime))
                || ((model.DeparturedateTime >= f.ArrivaldateTime) && (model.DeparturedateTime <= f.DeparturedateTime))))
                .FirstOrDefault() != null)
                {
                ModelState.AddModelError("", "Занято. Выберите другое время");
            }

            if (ModelState.IsValid)
            {
                Reservation reservation = new()
                {
                    ArrivaldateTime = model.ArrivaldateTime,
                    DeparturedateTime = model.DeparturedateTime,
                    NumberGuests = model.NumberGuests,
                    IdRoom = model.IdRoom,
                    IdUser = model.IdUser
                };

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "Number", model.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname", model.IdUser);
            return View(model);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "Description", reservation.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname", reservation.IdUser);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArrivaldateTime,DeparturedateTime,NumberGuests,IdRoom,IdUser")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "Description", reservation.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname", reservation.IdUser);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'AppCtx.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
