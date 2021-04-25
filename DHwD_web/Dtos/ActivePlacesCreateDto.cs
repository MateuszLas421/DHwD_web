using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class ActivePlacesCreateDto
    {
        public bool Active { get; set; }
        public Place Place { get; set; }
        public ActivePlacesCreateDto()
        { }
        public ActivePlacesCreateDto(Place place)
        {
            Active = true;
            Place = place;
        }
    }
}
