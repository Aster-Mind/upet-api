using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpetApi.DTOS;

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

        [HttpGet("{places}")]
        
        public async Task<ActionResult<List<string>>> Places()
        {
            var lugares = await context.Sedes.Select(x => x.municipio).Distinct().ToListAsync();

            return lugares;
        }


       


    }
}
