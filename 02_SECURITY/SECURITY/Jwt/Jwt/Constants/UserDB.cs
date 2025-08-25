using Jwt.Models;

namespace Jwt.Constants
{
    public class UserDB
    {
        public static readonly List<User> Users = new List<User>()
        {
            new User() {UserName = "anibal", Password = "123", 
                EmailAddess = "agma2560@gmail.com", FirstName = "Anibal", 
                LastName = "Martinez", Rol = "Administrador"},
            new User() {UserName = "ivan", Password = "321", 
                EmailAddess = "ivan@gmail.com", FirstName = "Ivan", 
                LastName = "Martinez", Rol = "CEO"},
            new User() {UserName = "jacob", Password = "555", 
                EmailAddess = "jacob@gmail.com", FirstName = "Jacob", 
                LastName = "Martinez", Rol = "Ingeniero"}
        };
    }
}
