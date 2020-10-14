using CRUD.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class ImageService
    {
        private readonly IMongoCollection<Image> _images;

        public ImageService(IImagesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _images = database.GetCollection<Image>(settings.ImagesCollectionName);
        }

        public List<Image> Get()
        {
         return _images.Find(image=> true).ToList();
        }
     }
}
