using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;
using UpetApi.Migrations;

namespace UpetApi.Controllers
{
    [ApiController]
    [Route("api/ongs")]
    public class OngsController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OngsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<OngsDTo>>> Get()
        {
            var entidades = await context.OngUsers
               
                .ToListAsync();

            var dtos = mapper.Map<List<OngsDTo>>(entidades);

            return dtos;
        }

        [HttpGet("{id:int}", Name = "obtenerOngs")]
        public async Task<ActionResult<OngsDTo>> Get(int id)
        {
            var entidad = await context.OngUsers
                .Include(sede => sede.sedes)
                .FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dto = mapper.Map<OngsDTo>(entidad);

            return dto;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OngCreacionDTO ong)
        {
            var entidad = mapper.Map<OngUsers>(ong);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var ongDTo = mapper.Map<OngsDTo>(entidad);

            return new CreatedAtRouteResult("obtenerMascota", new { id = ongDTo.id }, ongDTo);


        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] OngCreacionDTO ong)
        {
            var entidad = mapper.Map<OngUsers>(ong);

            entidad.id = id;

            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }


        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.OngUsers.AnyAsync(x => x.id == id);
            if (!existe) return NotFound();

            context.Remove(new OngUsers() { id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
