using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repository;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = new Guid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var region = nZWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();            
        }

        public async Task<Region> GetAsync(Guid id)
        {
            var region=await nZWalksDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            return region;
        }

        public async Task<Region> UpdateRegionsAsync(Guid id,Region region)
        {
            var existingregion=await nZWalksDbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
             
            if(existingregion==null)
            {
                return null;
            }

            existingregion.Code = region.Code;
            existingregion.Name = region.Name;
            existingregion.Area=region.Area;
            existingregion.Walks = region.Walks;
            existingregion.Lat=region.Lat;
            existingregion.Long=region.Long;
            existingregion.Population = region.Population;

            await nZWalksDbContext.SaveChangesAsync();
            return existingregion;
        }
    }
}
