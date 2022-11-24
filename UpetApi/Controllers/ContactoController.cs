using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/contacto")]
    public class ContactoController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ContactoController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<List<Contacto>> get()
        {
            var mensajes = await context.Contactos.ToListAsync();

            return mensajes;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contacto contacto)
        {
            context.Add(contacto);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Contactos.AnyAsync(x => x.id == id);
            if (!existe) return NotFound();

            context.Remove(new Contacto() { id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
