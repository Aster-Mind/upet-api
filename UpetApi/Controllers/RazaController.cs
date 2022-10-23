using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/razas")]
    public class RazaController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RazaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RazaDTO>>> Get()
        {
            var entidades = await context.Razas.ToListAsync();

            var dtos = mapper.Map<List<RazaDTO>>(entidades);

            return dtos;
        }


        [HttpGet("{id:int}", Name = "obtenerRaza")]
        public async Task<ActionResult<RazaDTO>> Get(int id)
        {
            var entidad = await context.Razas.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dto = mapper.Map<RazaDTO>(entidad);

            return dto;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RazaCreacionDTO raza)
        {
            var entidad = mapper.Map<Raza>(raza);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var razaDTO = mapper.Map<UsersDTO>(entidad);

            return new CreatedAtRouteResult("obtenerRaza", new { id = razaDTO.id }, razaDTO);


        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] RazaCreacionDTO raza)
        {
            var entidad = mapper.Map<Raza>(raza);
            entidad.id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }


        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Razas.AnyAsync(x => x.id == id);
            if (!existe) return NotFound();

            context.Remove(new Raza() { id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
