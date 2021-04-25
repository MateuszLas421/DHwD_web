using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class PlaceReadDto
    {
        public int Id { get; set; }
        public Games Games { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public int LocationRef { get; set; }
    }
}
