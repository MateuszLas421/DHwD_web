﻿using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class TeamMembersCreateDto
    {
        public int Id { get; set; }
        public Team Team { get; set; }// FK
    }
}
