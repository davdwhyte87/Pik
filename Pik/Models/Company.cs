using System;
namespace Pik.Models
{
    public class Company
    {
        public Company()
        {
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public User[] Models { get; set; }
    }
}
