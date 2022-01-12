namespace SignalR.Api.Model.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        #region Navigation property

        public ICollection<UserRoom>? UserRooms { get; set; }

        #endregion
    }
}
