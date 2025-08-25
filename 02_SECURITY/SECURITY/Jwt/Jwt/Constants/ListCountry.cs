using Jwt.Models;

namespace Jwt.Constants
{
    public class ListCountry
    {
        public static readonly List<Country> listCountry = new List<Country>()
        {
            new Country() {Name = "Colombia"},
            new Country() {Name = "Mexico"},
            new Country() {Name = "Chile"},
            new Country() {Name = "Argentina"}
        };
    }
}
