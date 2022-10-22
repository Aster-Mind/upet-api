using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using UpetApi.DTOS;
using UpetApi.Entidades;
using UpetApi.Helpers;

namespace UpetApi.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsersDTO>>> Get()
        {
            var entidades = await context.Users.ToListAsync();
            var dtos = mapper.Map<List<UsersDTO>>(entidades);
            return dtos;
        }


        [HttpGet("{id:int}", Name = "obtenerUser")]
        public async Task<ActionResult<UsersDTO>>Get(int id)
        {
            var entidad = await context.Users.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dto = mapper.Map<UsersDTO>(entidad);

            return dto;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreacionDTO user)
        {
            var entidad = mapper.Map<Users>(user);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var userDTo = mapper.Map<UsersDTO>(entidad);

            return new CreatedAtRouteResult("obtenerUser", new { id = userDTo.id }, userDTo);


        }

        [HttpPut]
        public async Task<ActionResult>Put(int id, [FromBody] UserCreacionDTO user)
        {
            var entidad = mapper.Map<Users>(user);
            entidad.id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Users.AnyAsync(x => x.id == Id);
            if (!existe) return NotFound();

            context.Remove(new Users() { id = Id });
            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("/login")]
        public async Task<ActionResult> Post([FromBody] LoginUserDTO user)
        {
         


            var existe = await context.Users.AnyAsync(x => x.correo == user.correo && x.password == user.password);
            if (existe) return NoContent();

            return BadRequest();

        }
    }
}
