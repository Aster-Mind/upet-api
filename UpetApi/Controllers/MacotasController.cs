using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{
    [ApiController]
    [Route("api/mascotas")]
    public class MacotasController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MacotasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }




        [HttpGet]
        public async Task<ActionResult<List<MascotasDTO>>> Get()
        {
            var entidades = await context.Mascotas.ToListAsync();

            var dtos = mapper.Map<List<MascotasDTO>>(entidades);


            var existeV = await context.Visitas.FirstOrDefaultAsync(x => x.mes == DateTime.Today.Month.ToString());
            if (existeV != null)
            {
                existeV.visitas += 1;
              
            }
            else
            {
                Visitas visita = new Visitas();

                visita.visitas = 1;
                visita.mes = DateTime.Today.Month.ToString();

                context.Add(visita);


            }

            await context.SaveChangesAsync();
        

            return dtos;
        }

        [HttpGet("{id:int}", Name = "obtenerMascota")]
        public async Task<ActionResult<MascotasDTO>> Get(int id)
        {
            var entidad = await context.Mascotas.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dto = mapper.Map<MascotasDTO>(entidad);

            return dto;
        }


       

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MascotasCreacionDTO mascota)
        {
            var entidad = mapper.Map<Mascota>(mascota);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var mascotaDTO = mapper.Map<MascotasDTO>(entidad);

            return new CreatedAtRouteResult("obtenerMascota", new { id = mascotaDTO.id }, mascotaDTO);


        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] MascotasCreacionDTO mascota)
        {
            var entidad = mapper.Map<Mascota>(mascota);
            entidad.id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }


        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Mascotas.AnyAsync(x => x.id == id);
            if (!existe) return NotFound();

            context.Remove(new Mascota() { id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("get")]
        public async Task<ActionResult<List<Mascota>>> Get2()
        {
            var entidades = await context.Mascotas.ToListAsync();

            //var dtos = mapper.Map<List<MascotasDTO>>(entidades);


            var existeV = await context.Visitas.FirstOrDefaultAsync(x => x.mes == DateTime.Today.Month.ToString());
            if (existeV != null)
            {
                existeV.visitas += 1;

            }
            else
            {
                Visitas visita = new Visitas();

                visita.visitas = 1;
                visita.mes = DateTime.Today.Month.ToString();

                context.Add(visita);


            }

            await context.SaveChangesAsync();


            return entidades;
        }
    }
}
