using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspMysqlCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMysqlCore.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Servers")]
    public class ServersController : Controller
    {
        private ApplicationDbContext _db;

        public ServersController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: api/Servers
        [HttpGet]
        public async Task<IEnumerable<Servers>> GetServer()
        {
            return await _db.Servers.ToListAsync();
        }

        // GET: api/Servers/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Servers> GetServer(int id)
        {
            return await _db.Servers.SingleOrDefaultAsync(m => m.Id == id);
        }
        
        // POST: api/Servers
        [HttpPost]
        public async Task<IActionResult> Post(Servers server)
        {
            if (ModelState.IsValid)
            {
                _db.Servers.Add(server);
                await _db.SaveChangesAsync();
                return BadRequest("Adding successful!");
            }
            return BadRequest("Please check data!");
        }
        
        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Servers server)
        {
            if(id != server.Id)
            {
                return BadRequest("Id not match!");
            }
            Servers serverInDB = await _db.Servers.SingleOrDefaultAsync(m => m.Id == id);
            if (serverInDB == null)
            {
                return BadRequest("No records found!");
            }
            serverInDB.Name = server.Name;
            serverInDB.ip_address = server.ip_address;
            _db.Update(serverInDB);
            await _db.SaveChangesAsync();
            return BadRequest("Update successful!");
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Servers server =  _db.Servers.SingleOrDefault(m => m.Id == id);
            _db.Remove(server);
            _db.SaveChanges();
        }
    }
}
