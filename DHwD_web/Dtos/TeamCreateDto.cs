﻿using Models.ModelsDB;

namespace DHwD_web.Dtos
{
    public class TeamCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StatusPassword { get; set; }  //Password Exist
        public string Password { get; set; }
        public string Description { get; set; }
        public bool OnlyOnePlayer { get; set; }
        public Games Games { get; set; }
        public StatusCreateDto StatusCreateDto { get; set; }
    }
}
