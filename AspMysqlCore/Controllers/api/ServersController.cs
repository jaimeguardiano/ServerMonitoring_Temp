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
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Servers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
