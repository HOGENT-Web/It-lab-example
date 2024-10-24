using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Materials;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Materials;

namespace Services.Materials
{
	public class MaterialService : IMaterialService
    {
        private readonly ApplicationDbContext dbContext;

        public MaterialService(ApplicationDbContext dbContext)
		{
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(MaterialDto.Create model)
        {
            var m = new Material(model.Name, model.Description);
            dbContext.Materials.Add(m);
            await dbContext.SaveChangesAsync();
            return m.Id;
        }

        public async Task<IEnumerable<MaterialDto.Index>> GetIndexAsync(string searchTerm)
        {
            var query = dbContext.Materials.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(x => x.Name.StartsWith(searchTerm)
                                         || x.Description.Contains(searchTerm));
            }

            query = query.OrderBy(x => x.Name);

            var materials =  await query.Select(x => new MaterialDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                InStock = x.InStock
            }).ToListAsync();

            return materials;
        }
    }
}

