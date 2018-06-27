using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst_Login.Models; 

namespace MVC_CodeFirst_Login.Controllers {
    [Produces("application/json")]
    [Route("api/Rest")]
    public class RestController : Controller {

        private OurDbContext _context;
     
        public RestController(OurDbContext context) {
            _context = context;
        }

        [Route("")]
        [HttpPost]
        public void AddHuisarts([FromBody] GeneralPractioner generalPractioner) {
            _context.Add(generalPractioner);                   
        }
 

        [HttpGet("all")]
        public IEnumerable<GeneralPractioner> GetAllGP() {
            return _context.GeneralPractioner.ToList();
          
        }

    }
}