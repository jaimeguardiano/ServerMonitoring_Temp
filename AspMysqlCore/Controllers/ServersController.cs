using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMysqlCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMysqlCore.Controllers
{
    public class ServersController : Controller
    {
        private ApplicationDbContext _db;

        public ServersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Servers.ToList());
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST: Servers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servers server)
        {
            if (!ModelState.IsValid)
            {
                return View(server);
            }

            _db.Servers.Add(server);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        //GET: Servers/Details/Id
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var server = await _db.Servers.SingleOrDefaultAsync(m => m.Id == Id);
            if (server == null)
            {
                return NotFound();
            }
            else
            {
                return View(server);
            }
        }


        //GET: Servers/Edit/Id
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var server = await _db.Servers.SingleOrDefaultAsync(m => m.Id == Id);
            if (server == null)
            {
                return NotFound();
            }
            else
            {
                return View(server);
            }
        }

        //POST: Servers/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servers server)
        {
            if ((id != server.Id) || !(ModelState.IsValid))
            {
                return View(server);
            }

            var serverInDb = await _db.Servers.SingleOrDefaultAsync(m => m.Id == id);
            if (serverInDb == null)
            {
                return NotFound();
            }
            serverInDb.Name = server.Name;
            serverInDb.ip_address = server.ip_address;
            _db.Servers.Update(serverInDb);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //TEST

        //GET: Servers/Delete/Id
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var server = await _db.Servers.SingleOrDefaultAsync(m => m.Id == Id);
            if (server == null)
            {
                return NotFound();
            }
            else
            {
                return View(server);
            }
        }

        //POST: Servers/Delete/Id
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serverInDb = await _db.Servers.SingleOrDefaultAsync(m => m.Id == id);
            if (serverInDb == null)
            {
                return NotFound();
            }

            _db.Servers.Remove(serverInDb);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

    }
}