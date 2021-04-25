using System;

namespace DHwD_web.Dtos
{
    public class PointsCreateDto
    {
        public int UserPoints { get; set; }
        public DateTime DataTimeEdit { get; set; }
        public DateTime DataTimeCreate { get; set; }
        //public PointsCreateDto()
        //{
        //    UserPoints = 0;
        //    DataTimeEdit = DateTime.UtcNow;
        //    DataTimeCreate = DateTime.UtcNow;
        //}
    }
}
