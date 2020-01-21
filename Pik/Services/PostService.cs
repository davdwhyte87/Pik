using System;
using Pik.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Pik.Services
{
    public class PostService
    {
        private readonly IMongoCollection<Post> _post;
        public PostService(IPikDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _post = database.GetCollection<Post>(settings.PostCollectionName);
        }

        public List<Post> Get() =>
            _post.Find(Post => true).ToList();

        public Post Get(string id) =>
            _post.Find<Post>(Post => Post.Id == id).FirstOrDefault();

        public Post Create(Post post)
        {
            _post.InsertOne(post);
            return post;
        }

        public void Update(string id, Post postIn) =>
            _post.ReplaceOne(post => post.Id == id, postIn);
    }
}
