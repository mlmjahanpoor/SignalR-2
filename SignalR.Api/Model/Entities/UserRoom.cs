namespace SignalR.Api.Model.Entities
{
    public class UserRoom
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public Room Room { get; set; }
        public Guid RoomId { get; set; }
    }
}
