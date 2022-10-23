using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/ong/{ongId:int}/sedes")]
    public class SedeController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SedeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<SedesDTO>>> Get(int ongId)
        {
            var existeOng = await context.OngUsers.AnyAsync(x => x.id == ongId);
            if (!existeOng) return NotFound();

            var entidades = await context.Sedes
                .Where(x => x.ongId == ongId)
                .ToListAsync();
            var dtos = mapper.Map<List<SedesDTO>>(entidades);
            return dtos;
        }


        [HttpGet("{id}", Name ="obtenerSede")]
        public async Task<ActionResult<SedesDTO>> Get(int ongId, int id)
        {
            var existeOng = await context.OngUsers.AnyAsync(x => x.id == ongId);
            if (!existeOng) return NotFound();

            var entidad = await context.Sedes.FirstOrDefaultAsync(x => x.id == id && x.ongId == ongId);

            if (entidad == null) return NotFound();

            var dtos = mapper.Map<SedesDTO>(entidad);
            return dtos;
        }


        [HttpPost]
        public async Task<ActionResult> Post(int ongId,[FromBody] SedeCreacionDTO sede)
        {

            var existeOng = await context.OngUsers.AnyAsync(x => x.id == ongId);
            if (!existeOng) return NotFound();


            var entidad = mapper.Map<Sede>(sede);
            entidad.ongId = ongId;
            context.Add(entidad);
            await context.SaveChangesAsync();

            return Ok();

            //var sedeDTO = mapper.Map<SedesDTO>(entidad);

            //return new CreatedAtRouteResult("obtenerSede", new { id = sedeDTO.id }, sedeDTO);


        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] SedeCreacionDTO sede)
        {
            var entidad = mapper.Map<Sede>(sede);
            entidad.id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int ongId,int id)
        {
            var existe = await context.Sedes.AnyAsync(x => x.id == id && x.ongId == ongId);
            if (!existe) return NotFound();

            context.Remove(new Sede() { id = id, ongId = ongId });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
