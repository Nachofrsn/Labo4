namespace concesionarioAPI.Models.User.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string UserName { get; set; } = null!;
    }
}
