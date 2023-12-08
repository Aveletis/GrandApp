using GrandApp.Models;
using GrandApp.Models.Data;
using GrandApp.ViewModels.RoomPrices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Controllers
{
    public class RoomPricesController : Controller
    {
        private readonly AppCtx _context;

        public RoomPricesController(AppCtx context)
        {
            _context = context;
        }

        // GET: RoomPrices
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.RoomPrices
               .OrderBy(f => f.PriceSettingdateTime);

            return View(await appCtx.ToListAsync());
        }

        //УДАЛЕН ЗА НЕНАДОБНОСТЬЮ
        // GET: RoomPrices/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomPrices == null)
            {
                return NotFound();
            }

            var RoomPrices = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (RoomPrices == null)
            {
                return NotFound();
            }

            return View(RoomPrices);
        }*/

        // GET: RoomPrices/Create
        public IActionResult Create()
        {
            ViewData["IdRoomCategory"] = new SelectList(_context.RoomCategories, "Id", "Category");
            return View();
        }

        // POST: RoomPrices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoomPricesViewModel model)
        {
            if (ModelState.IsValid)
            {
                RoomPrice price = new()
                {
                    CostOneSM = model.CostOneSM,
                    IdRoomCategory = model.IdRoomCategory
                };

                _context.Add(price);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRoomCategory"] = new SelectList(
                _context.RoomCategories,
                "Id", "Category", model.IdRoomCategory);
            return View(model);
        }

        //УДАЛЕН ЗА НЕНАДОБНОСТЬЮ
        /* // GET: RoomPrices/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null || _context.RoomPrices == null)
             {
                 return NotFound();
             }

             var price = await _context.RoomPrices.FindAsync(id);
             if (price == null)
             {
                 return NotFound();
             }

             EditRoomPricesViewModel model = new()
             {
                 Id = price.Id,
                 CostOneSM = price.CostOneSM,
                 IdRoomCategory = price.IdRoomCategory
             };
             ViewData["IdRoomCategory"] = new SelectList(
                 _context.RoomCategories,
                 "Id", "Category", price.IdRoomCategory);
             return View(model);
         }

         // POST: RoomPrices/Edit/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, EditRoomPricesViewModel model)
         {
             RoomPrice price = await _context.RoomPrices.FindAsync(id);

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
         }*/

        // GET: RoomPrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomPrices == null)
            {
                return NotFound();
            }

            var roomPrice = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomPrice == null)
            {
                return NotFound();
            }

            return View(roomPrice);
        }

        // POST: RoomPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomPrices == null)
            {
                return Problem("Entity set 'AppCtx.RoomPrices'  is null.");
            }
            var roomPrice = await _context.RoomPrices.FindAsync(id);
            if (roomPrice != null)
            {
                _context.RoomPrices.Remove(roomPrice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomPriceExists(int id)
        {
            return (_context.RoomPrices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
