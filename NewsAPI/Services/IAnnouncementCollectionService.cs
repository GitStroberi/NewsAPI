using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace NewsAPI.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement, AnnouncementNoId>
    {
        Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);

        
    }
}
