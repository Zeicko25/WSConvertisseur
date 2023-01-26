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
        public ActionResult<Devise>GetById(int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        // POST api/<DevisesController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Devise> Delete(int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            } devises.Remove(devise);
            return devise;
        }
    }
}
