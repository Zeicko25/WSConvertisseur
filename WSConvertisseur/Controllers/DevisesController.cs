﻿using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        List<Devise> devises = new List<Devise>();

        public DevisesController()
        {
            

            devises.AddRange(new List<Devise>
            {
                 new Devise(1, "Dollar", 1.08),
                 new Devise(2, "Franc Suisse", 1.07),
                 new Devise(3, "Yen", 120)
            }
            );
        }
        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }


        // GET api/<DevisesController>/5
        [HttpGet("{id}")]
        public string GetAll(int id, string nomDevise, double taux)
        {
            return "value";
        }

        // POST api/<DevisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
