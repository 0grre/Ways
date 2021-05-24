using System;

namespace Ways_DAO.Models
{
    public class Answer
    {
        public DateTime CreatedAt { get; set; }
        
        public User User { get; set; }
        public GameChoice GameChoice { get; set; }
        public OrientationChoice OrientationChoice { get; set; }

        public Answer()
        {
            CreatedAt = DateTime.Now;
        }

        public Answer(User user, GameChoice choice)
        {
            User = user;
            GameChoice = choice;
            CreatedAt = DateTime.Now;
        }

        public Answer(User user, OrientationChoice choice)
        {
            User = user;
            OrientationChoice = choice;
            CreatedAt = DateTime.Now;
        }
    }
}