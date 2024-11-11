namespace Celestial.API.Domain.Data.Interfaces
{
    public interface IStarRepository
    {
        Task<Star?> GetStarByIdAsync(int id);

        Task<List<Star>?> GetAllStarsAsync();

        Task AddStarAsync(Star star);
        Task UpdateStarAsync(Star star);
        Task DeleteStarAsync(int id);
    }
}
