using GrandApp.Models;
using GrandApp.Models.Data;
using GrandApp.ViewModels.RoomCategories;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Controllers
{
    public class RoomCategoriesController : Controller
    {
        private readonly AppCtx _context;

        public RoomCategoriesController(AppCtx context)
        {
            _context = context;
        }

        // GET: RoomCategories
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.RoomCategories
                .OrderBy(f => f.Category);

            return View(await appCtx.ToListAsync());
            /* return _context.RoomCategories != null ? 
                           View(await _context.RoomCategories.ToListAsync()) :
                           Problem("Entity set 'AppCtx.RoomCategories'  is null.");*/
        }

        // GET: RoomCategories/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var RoomCategories = await _context.RoomCategories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (RoomCategories == null)
            {
                return NotFound();
            }

            return View(RoomCategories);
        }

        // GET: RoomCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoomCategoriesViewModel model)
        {
            if (_context.RoomCategories
                .Where(f => f.Category == model.Category)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенная категория уже существует");
            }

            if (ModelState.IsValid)
            {
                RoomCategory category = new()
                {
                    Category = model.Category,
                    Description = model.Description
                };

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RoomCategories/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            EditRoomCategoriesViewModel model = new()
            {
                Id = roomCategory.ID,
                Category = roomCategory.Category,
                Description = roomCategory.Description
            };
            return View(model);
        }

        // POST: RoomCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, EditRoomCategoriesViewModel model)
        {
            RoomCategory category = await _context.RoomCategories.FindAsync(id);

            if (_context.RoomCategories
                .Where(f => f.Category == model.Category)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенная категория уже существует");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.Category = model.Category;
                    category.Description = model.Description;
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomCategoryExists(category.ID))
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
            return View(model);
        }

        // GET: RoomCategories/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.RoomCategories == null)
            {
                return NotFound();
            }

            var roomCategory = await _context.RoomCategories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            return View(roomCategory);
        }

        // POST: RoomCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.RoomCategories == null)
            {
                return Problem("Entity set 'AppCtx.RoomCategory'  is null.");
            }
            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory != null)
            {
                _context.RoomCategories.Remove(roomCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomCategoryExists(byte id)
        {
          return (_context.RoomCategories?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
