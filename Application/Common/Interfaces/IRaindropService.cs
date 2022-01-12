using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRaindropService
    {
        Task Post(Raindrop @new, long from);
    }
}
