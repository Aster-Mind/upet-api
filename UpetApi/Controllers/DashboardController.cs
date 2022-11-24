using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DashboardController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("places")]
        
        public async Task<ActionResult<List<string>>> Places()
        {
            var lugares = await context.Sedes.Select(x => x.municipio).Distinct().ToListAsync();

            return lugares;
        }

        [HttpGet("visitas")]
        public async Task<ActionResult<Visitas>> Visitas()
        {
            var visitas = await context.Visitas.FirstOrDefaultAsync(x => x.mes == DateTime.Today.Month.ToString());
           
            return visitas;
        }

        [HttpGet("adopciones")]
        public async Task<ActionResult<int>> Adopciones()
        {
            var adopciones = await context.Mascotas.CountAsync(x => x.adoptado == true);

            return adopciones;
        }

        [HttpGet("nOngs")]
        public async Task<ActionResult<int>> Ongss()
        {
            var adopciones = await context.Organizacions.CountAsync();

            return adopciones;
        }


        [HttpGet("adopcionRaza")]

        public async Task<ActionResult<List<adopcionRazaDTO>>> adpRaza()
        {
            var top3 = await context.Mascotas
                .Select(x => new
                {
                    x.raza,
                    x.tipo

                })
                .Distinct()
                .ToListAsync();
            List<adopcionRazaDTO> lis = new List<adopcionRazaDTO>();

            foreach(var item in top3)
            {
                lis.Add(new adopcionRazaDTO
                {
                    raza=$"{item.tipo} {item.raza}",

                    cantidad = await context.Mascotas.CountAsync(x => x.raza == item.raza)
                });
            }

            return lis;

        }
        [HttpGet("verificacion/{id}")]
        public async Task<ActionResult<organizacion>> verf(int id)
        {
            var ong = await context.Organizacions.FirstOrDefaultAsync(x => x.id == id);

            ong.verificado = true;
            context.Entry(ong).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return ong;


        }

        [HttpGet("noVer")]
        public async Task<ActionResult<List<organizacion>>> verf()
        {
            var ong = await context.Organizacions.Where(x => x.verificado == false).ToListAsync();

         

            return ong;


        }


        [HttpGet("sedes")]
        public async Task<ActionResult<List<organizacion>>> Get()
        {



            var ong = await context.Organizacions.Where(x => x.verificado == true).ToListAsync();



            return ong;
        }


        [HttpGet("sedes/{id}")]
        public async Task<ActionResult<organizacion>> Get(int id)
        {



            var ong = await context.Organizacions.FirstOrDefaultAsync(x =>x.id == id&& x.verificado == true);



            return ong;
        }

        //[HttpGet("fMascotas/{?tipo}/{?raza}")]
        //public async Task<ActionResult<List<Mascota>>> GetMAtas(string ?raza, string ?tipo)
        //{

        //    var entidades = await context.Mascotas
        //        .Where(x => (raza != null && raza != "" ? x.raza == raza:false) && (tipo != null && tipo != "" ? x.tipo == tipo : false))
        //        .ToListAsync();
        //    return entidades;

        //}

        [HttpPost("add/ong")]
        public async Task<ActionResult> Post([FromBody] organizacion user)
        {
      
            context.Add(user);
            await context.SaveChangesAsync();

            

            return new CreatedAtRouteResult("obtenerUser", new { id = user.id }, user);


        }

        [HttpGet("adopciones/{ong}")]
        public async Task<ActionResult<int>> Adopciones(string ong)
        {
            var adopciones = await context.Mascotas.CountAsync(x => x.adoptado == true && x.duenoNombre == ong);

            return adopciones;
        }
        [HttpGet("mascotas/{ong}")]
        public async Task<ActionResult<int>> AdopcionesTot(string ong)
        {
            var adopciones = await context.Mascotas.CountAsync(x=> x.duenoNombre == ong);

            return adopciones;
        }
        [HttpGet("get/{ong}")]
        public async Task<ActionResult<List<Mascota>>> Get2(string ong)
        {
            var entidades = await context.Mascotas
                .Where(x => x.duenoNombre == ong)
                .ToListAsync();

            //var dtos = mapper.Map<List<MascotasDTO>>(entidades);


            return entidades;
        }
    }
}
