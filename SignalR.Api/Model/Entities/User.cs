namespace SignalR.Api.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        #region Navigation properties

        public ICollection<UserRoom>? UserRooms { get; set; }

        #endregion
    }
}
