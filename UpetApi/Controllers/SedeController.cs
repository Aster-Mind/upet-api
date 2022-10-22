using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/sedes")]
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
        public async Task<ActionResult<List<SedesDTO>>> Get()
        {
            var entidades = await context.Sedes.ToListAsync();
            var dtos = mapper.Map<List<SedesDTO>>(entidades);
            return dtos;
        }


        [HttpGet("{id}", Name ="obtenerSede")]
        public async Task<ActionResult<SedesDTO>> Get(int id)
        {
            var entidad = await context.Sedes.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dtos = mapper.Map<SedesDTO>(entidad);
            return dtos;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SedeCreacionDTO sede)
        {
            var entidad = mapper.Map<Sede>(sede);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var sedeDTO = mapper.Map<SedesDTO>(entidad);

            return new CreatedAtRouteResult("obtenerSede", new { id = sedeDTO.id }, sedeDTO);


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
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Sedes.AnyAsync(x => x.id == Id);
            if (!existe) return NotFound();

            context.Remove(new Sede() { id = Id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
