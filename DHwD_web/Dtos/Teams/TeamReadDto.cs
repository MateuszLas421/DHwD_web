namespace DHwD_web.Dtos
{
    public class TeamReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StatusPassword { get; set; }
        public string Description { get; set; }
        public bool OnlyOnePlayer { get; set; }
        public int StatusRef { get; set; }
    }
}
