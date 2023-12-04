using GrandApp.Models.Data;
using GrandApp.Models;
using GrandApp.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppCtx _context;

        public UsersController(AppCtx context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Users
                .OrderBy(f => f.FirstName);

            return View(await appCtx.ToListAsync());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUsersViewModel model)
        {
            if (_context.Users
                .Where(f => f.Email == model.Email)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенный пользователь уже существует");
            }

            if (ModelState.IsValid)
            {
                User user = new()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    LastName = model.LastName,
                    FirstName = model.FirstName
                };

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Users/Edit
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            EditUsersViewModel model = new()
            {
                Id = user.Id,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName
            };
            return View(model);
        }

        // POST: Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUsersViewModel model)
        {
            User user = await _context.Users.FindAsync(id);

            if (_context.Users
                .Where(f => f.Email == model.Email && f.Id != model.Id)
                .FirstOrDefault() != null)
            {
                ModelState.AddModelError("", "Введенный пользователь уже существует");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.LastName = model.LastName;
                    user.FirstName = model.FirstName;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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

        // GET: Users/Delete
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppCtx.User'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
