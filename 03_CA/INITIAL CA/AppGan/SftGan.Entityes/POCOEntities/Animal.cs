using AppGan.Entities.Enums;

namespace AppGan.Entities.POCOEntities
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Number { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string? race { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Sex {  get; set; } = string.Empty;
        public Status Status {  get; set; }
    }
}
