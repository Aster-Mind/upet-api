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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsersDTO>>Get(int id)
        {
            var entidad = await context.Users.FirstOrDefaultAsync(x => x.id == id);

            if (entidad == null) return NotFound();

            var dto = mapper.Map<UsersDTO>(entidad);

            return dto;

        }

        [HttpPost]
        public async Task<ActionResult> Post(UsersDTO user)
        {

        }
    }
}
