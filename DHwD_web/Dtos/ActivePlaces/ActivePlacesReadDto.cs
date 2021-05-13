using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class ActivePlacesReadDto
    {
        public int ID { get; set; }

        public bool Active { get; set; }

        public string Type { get; set; }

        public bool IsEndPlace { get; set; }

        public Place Place { get; set; }
    }
}
