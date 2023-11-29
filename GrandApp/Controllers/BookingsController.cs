using GrandApp.Models;
using GrandApp.Models.Data;
using GrandApp.ViewModels.Booking;
using GrandApp.ViewModels.RoomCategories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppCtx _context;
        private readonly UserManager<User> _userManager;

        public BookingsController(
            AppCtx context,
            UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Booking;

            return View(await appCtx.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        //НЕРАБОТАЕТ
        public async Task<IActionResult> Create(CreateBookingViewModel model)
        {
            if (_context.RoomCategories
                .Where(f => f.Category == model.IdUser)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенная категория уже существует");
            }

            if (ModelState.IsValid)
            {
                RoomCategory category = new()
                {
                    Category = model.IdUser
                };

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArrivaldateTime,DeparturedateTime,NumberGuests")] Booking booking)
        {
            if (id != booking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.ID))
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
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .FirstOrDefaultAsync(m => m.ID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Booking == null)
            {
                return Problem("Entity set 'AppCtx.Booking'  is null.");
            }
            var booking = await _context.Booking.FindAsync(id);
            if (booking != null)
            {
                _context.Booking.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Booking?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
