using System;
using Pik.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Pik.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IPikDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> Get() =>
            _user.Find(User => true).ToList();

        public User Get(string id) =>
            _user.Find<User>(User => User.Id == id).FirstOrDefault();

        public User GetByEmail(string email)
        {
           return _user.Find<User>(User => User.Email == email).FirstOrDefault();
        }
        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _user.ReplaceOne(user => user.Id == id, userIn);
    }
}
