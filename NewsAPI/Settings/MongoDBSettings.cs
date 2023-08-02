namespace NewsAPI.Settings
{
    public class MongoDBSettings : IMongoDBSettings
    {
        //public string AnnouncementsCollectionName { get =>  throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string AnnouncementsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        
    }
}
