using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models;

namespace MVC_CodeFirst_Login.Controllers.Rest
{
    [Produces("application/json")]
    [Route("api/consult")]
    public class ConsultRestService : Controller {

        private OurDbContext _context;

        public ConsultRestService(OurDbContext context) {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public void AddConsult([FromBody] Consult consult) {
            _context.Add(consult);
        }

        [HttpGet("{id}")]
        public IQueryable<Consult> GetConsult(string id) {
            int Pid = Convert.ToInt32(id);
            var consult = from p in _context.Consult
                          where p.ConsultId == Pid
                          select p;
            return consult;
        }

        [HttpGet("all")]
        public IEnumerable<Consult> GetAllConsults() {
            return _context.Consult.ToList();
        }

    }
}


