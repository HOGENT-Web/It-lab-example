using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Materials;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService materialService;

        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        [HttpGet]
        public Task<IEnumerable<MaterialDto.Index>> GetIndex([FromQuery]string searchTerm)
        {
            return materialService.GetIndexAsync(searchTerm);
        }
        
        [HttpPost]
        public Task<int> Create([FromBody] MaterialDto.Create model)
        {
            return materialService.CreateAsync(model);
        }

        
    }
}
