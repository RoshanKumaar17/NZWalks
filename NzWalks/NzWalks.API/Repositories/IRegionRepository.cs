using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddRegionAsync(Region region);
        Task<Region> DeleteRegionAsync(Guid id);

        Task<Region> UpdateRegionsAsync(Guid id,Region region);
    }
}
