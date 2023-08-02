using MongoDB.Driver;
using NewsAPI.Models;
using NewsAPI.Settings;

namespace NewsAPI.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {

        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }

        public async Task<bool> Create(Announcement announcement)
        {
            if (announcement.Id == Guid.Empty)
            {
                announcement.Id = Guid.NewGuid();
            }

            await _announcements.InsertOneAsync(announcement);
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var result = await _announcements.DeleteOneAsync(announcement => announcement.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }


        public async Task<Announcement> Get(Guid id)
        {
            return (await _announcements.FindAsync(announcement => announcement.Id == id)).FirstOrDefault();
        }


        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {
            return (await _announcements.FindAsync(announcement => announcement.CategoryId == categoryId)).ToList();
        }

        public async Task<bool> Update(Guid id, Announcement announcement)
        {
            announcement.Id = id;
            var result = await _announcements.ReplaceOneAsync(announcement => announcement.Id == id, announcement);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _announcements.InsertOneAsync(announcement);
                return false;
            }

            return true;
        }

        public async Task<bool> Update(Guid id, AnnouncementNoId announcement)
        {
            var result = await _announcements.UpdateOneAsync(announcement => announcement.Id == id, Builders<Announcement>.Update.Set("Title", announcement.Title).Set("Message", announcement.Message));
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                return false;
            }
            return true;
        }



        //List<Announcement> _announcements = new List<Announcement> { new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "First Announcement", Message = "First Announcement Message" , Author = "Author_1"},
        //new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Second Announcement", Message = "Second Announcement Message", Author = "Author_1" },
        //new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Third Announcement", Message = "Third Announcement Message", Author = "Author_2"  },
        //new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fourth Announcement", Message = "Fourth Announcement Message", Author = "Author_3"  },
        //new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fifth Announcement", Message = "Fifth Announcement Message", Author = "Author_4"  },
        //};
    }
}
