using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>

        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name ="GetDevise")]
        public ActionResult<Devise>GetById(int id)
        {
            Devise? devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">The devise of the currency</param>
        /// <response code="200">valid currency, new record returned</response>
        /// <response code="400 Bad Request">when the nameDevise is not filled in</response>

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

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">The devise of the currency</param>
        /// <param id="id">The devise of the currency</param>
        /// <response code="204 No Content">currency updated in the list</response>
        /// <response code="400 Bad Request">incorrect type of information</response>
        /// <response code="400 Bad Request">bad id in get</response>
        /// // <response code="404 Not Found">unknown id</response>


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

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">The devise of the currency</param>
        /// <param id="id">The devise of the currency</param>
        /// <response code="204 No Content">currency updated in the list</response>
        /// <response code="400 Bad Request">incorrect type of information</response>

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
