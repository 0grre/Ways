using System;

namespace Ways_DAO.Models
{
    public class Orientation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime CreatedAt { get; set; }

        public Orientation()
        {
            CreatedAt = DateTime.Now;
        }
    }
}