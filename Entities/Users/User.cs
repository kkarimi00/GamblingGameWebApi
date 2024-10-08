using GamblingGameWebApi.Entities.Domains.GambleRequests;
using Infrastructure.Entities;
using System.Reflection.Metadata;

namespace GamblingGameWebApi.Entities.Domains.Users
{
    public class User//: Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InitialPoint { get; set; }
        public int CurrentPoint { get; set; }
        public ICollection<GambleRequest> Requests { get; set; } = new List<GambleRequest>();
    }
}
