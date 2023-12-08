using GrandApp.Models;
using GrandApp.Models.Data;
using GrandApp.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppCtx _context;

        public RoomsController(AppCtx context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Rooms
               .OrderBy(f => f.Number);

            return View(await appCtx.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var Rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Rooms == null)
            {
                return NotFound();
            }

            return View(Rooms);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["IdRoomCategory"] = new SelectList(_context.RoomCategories, "Id", "Category");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoomsViewModel model)
        {
            if (_context.Rooms
                .Where(f => f.Number == model.Number)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенная комната уже существует");
            }

            if (ModelState.IsValid)
            {
                Room room = new()
                {
                    Number = model.Number,
                    Image = model.Image,
                    Floor = model.Floor,
                    NumberGuests = model.NumberGuests,
                    Square = model.Square,
                    Description = model.Description,
                    IdRoomCategory = model.IdRoomCategory
                };

                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRoomCategory"] = new SelectList(
                _context.RoomCategories,
                "Id", "Category", model.IdRoomCategory);
            return View(model);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            EditRoomsViewModel model = new()
            {
                Id = room.Id,
                Number = room.Number,
                Image = room.Image,
                Floor = room.Floor,
                NumberGuests = room.NumberGuests,
                Square = room.Square,
                Description = room.Description,
                IdRoomCategory = room.IdRoomCategory
            };
            ViewData["IdRoomCategory"] = new SelectList(
                _context.RoomCategories,
                "Id", "Category", room.IdRoomCategory);
            return View(model);
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, EditRoomsViewModel model)
        {
            Room room = await _context.Rooms.FindAsync(id);

            if (_context.Rooms
                .Where(f => f.Number == model.Number && f.Id != model.Id)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенная комната уже существует");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    room.Number = model.Number;
                    room.Image = model.Image;
                    room.Floor = model.Floor;
                    room.NumberGuests = model.NumberGuests;
                    room.Square = model.Square;
                    room.Description = model.Description;
                    room.IdRoomCategory = model.IdRoomCategory;
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
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
            ViewData["IdRoomCategory"] = new SelectList(
                _context.RoomCategories,
                "Id", "Category", room.IdRoomCategory);
            return View(model);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'AppCtx.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(byte id)
        {
            return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
