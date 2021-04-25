using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class StatusCreateDto
    {
        public int ID { get; set; }
        public Team Team { get; set; }
        public StatusCreateDto()
        { }
        public StatusCreateDto(Team team)
        {
            Team = team;
        }
    }
}
